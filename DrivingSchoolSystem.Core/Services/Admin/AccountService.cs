using DrivingSchoolSystem.Core.Contracts.Admin;
using DrivingSchoolSystem.Core.Models.Admin.Account;
using DrivingSchoolSystem.Core.Models.Category;
using DrivingSchoolSystem.Infrastructure.Data;
using DrivingSchoolSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DrivingSchoolSystem.Core.Services.Admin
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext context;

        public AccountService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public IEnumerable<AccountViewModel> GetAllByDrivingSchoolId(int drivingSchoolId)
        {
            var isAdmin = drivingSchoolId == -1;

            return context.Accounts
                .AsNoTracking()
                .Include(a => a.Role)
                .Include(a => a.DrivingSchool)
                .Where(a => 
                (isAdmin ? !a.IsDeleted :  a.DrivingSchoolId == drivingSchoolId && !a.IsDeleted) && a.Role.NormalizedName != "MANAGER")
                .Select(a => new AccountViewModel()
                {
                    Id = a.Id,
                    FullName = $"{a.FirstName} {a.MiddleName} {a.LastName}",
                    RoleName = ConvertRoleNameToBulgarianLang(a.Role.Name),
                    PhoneNumber = a.PhoneNumber,
                    DrivingSchoolName = isAdmin ? a.DrivingSchool.Name : null
                });
        }

        public async Task<IEnumerable<RoleModel>> GetRolesAsync()
        {
            return await context.Roles
                .AsNoTracking()
                .Where(r => r.NormalizedName != "MANAGER" && r.NormalizedName != "ADMIN")
                .Select(r => new RoleModel()
                {
                    Id = r.Id,
                    Name = ConvertRoleNameToBulgarianLang(r.Name)
                }).ToListAsync();
        }

        public async Task AddAsync(AddAccountModel model)
        {
            if (context.Accounts
                .Where(a => a.DrivingSchoolId == model.DrivingSchoolId)
                .Any(a => a.NormalizedEmail == model.Email.ToUpper()))
            {
                throw new ArgumentException("Already has account with this email!!!");
            }

            var account = new Account()
            {
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber,
                Email = model.Email,
                NormalizedEmail = model.Email.ToUpper(),
                DrivingSchoolId = model.DrivingSchoolId,
                RoleId = model.RoleId
            };

            await context.Accounts.AddAsync(account);

            var role = await context.Roles
                .AsNoTracking()
                .FirstAsync(r => r.Id == account.RoleId);

            if (role == null)
            {
                throw new NullReferenceException("Role cannot find!");
            }

            if (role.NormalizedName == "STUDENT")
            {
                var student = new Student();

                student.AccountId = account.Id;

                await context.Students.AddAsync(student);
            }
            else if (role.NormalizedName == "INSTRUCTOR")
            {
                var instructor = new Instructor();

                instructor.AccountId = account.Id;

                var categories = model.Categories
                    .Where(c => c.IsMarked)
                    .Select(c => new InstructorCategory()
                    {
                        Instructor = instructor,
                        CategoryId = c.Id
                    });

                await context.InstructorsCategories.AddRangeAsync(categories);

                await context.Instructors.AddAsync(instructor);
            }

            await context.SaveChangesAsync();
        }

        public async Task<List<CategoryModel>> GetCategoriesAsync()
        {
            return await context.Categories
                .AsNoTracking()
                .Select(c => new CategoryModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
        }

        public async Task<AccountInfoViewModel> GetInfoByIdAsync(Guid accountId, string role)
        {
            bool isAdmin = role.ToUpper() == "ADMIN" ? true : false;

            var account = await context.Accounts
                .AsNoTracking()
                .Include(a => a.Role)
                .Include(a => a.DrivingSchool)
                .FirstAsync(a => a.Id == accountId && a.Role.NormalizedName != "MANAGER");

            return new AccountInfoViewModel()
            {
                Id = account.Id,
                FirstName = account.FirstName,
                MiddleName = account.MiddleName,
                LastName = account.LastName,
                PhoneNumber = account.PhoneNumber,
                Email = account.Email,
                Registered = account.UserId != null ? "Да" : "Не",
                RoleName = ConvertRoleNameToBulgarianLang(account.Role.Name),
                DrivingSchoolName = isAdmin ? account.DrivingSchool.Name : null
            };
        }

        public async Task Delete(Guid id)
        {
            var account = await context.Accounts
                .Include(a => a.Role)
                .FirstOrDefaultAsync(a => a.Id == id && a.Role.NormalizedName != "MANAGER");

            if (account == null)
            {
                throw new NullReferenceException("Account cannot find!");
            }

            account.IsDeleted = true;

            if (account.Role.NormalizedName == "STUDENT")
            {
                foreach (var studentCard in context.StudentCards
                    .Include(sc => sc.Student.Account)
                    .Where(sc => sc.Student.AccountId == account.Id))
                {
                    studentCard.IsDeleted = true;
                }
            }
            else if (account.Role.NormalizedName == "INSTRUCTOR")
            {
                foreach (var studentCard in context.StudentCards
                   .Include(sc => sc.Instructor.Account)
                   .Where(sc => sc.Instructor.AccountId == account.Id))
                {
                    studentCard.IsDeleted = true;
                }
            }

            await context.SaveChangesAsync();
        }
        
        public async Task<AccountEditServiceModel> GetEditModelByIdAsync(Guid accountId)
        {
            var account = await context.Accounts
                .AsNoTracking()
                .Include(a => a.Role)
                .FirstAsync(a => a.Id == accountId && a.Role.NormalizedName != "MANAGER");

            var model = new AccountEditServiceModel()
            {
                Id = account.Id,
                FirstName = account.FirstName,
                MiddleName = account.MiddleName,
                LastName = account.LastName,
                PhoneNumber = account.PhoneNumber,
                Email = account.Email,
                RoleName = ConvertRoleNameToBulgarianLang(account.Role.Name)
            };

            if (account.Role.NormalizedName == "INSTRUCTOR")
            {
                var instructor = await context.Instructors
                .Include(i => i.InstructorsCategories)
                .ThenInclude(ic => ic.Category)
                .FirstAsync(i => i.AccountId == account.Id);

                model.Categories = await context.Categories
                .Select(c => new CategoryModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    
                })
                .ToListAsync();

                foreach (var category in model.Categories)
                {
                    category.IsMarked = instructor.InstructorsCategories
                                            .Any(ic => ic.CategoryId == category.Id);
                }
            }

            return model;
        }

        public async Task EditAsync(AccountEditServiceModel model)
        {
            var account = await context.Accounts
                .Include(a => a.Role)
                .FirstAsync(a => a.Id == model.Id && a.Role.NormalizedName != "MANAGER");

            if (account == null)
            {
                throw new NullReferenceException("Account cannot find!");
            }

            account.FirstName = model.FirstName;
            account.MiddleName = model.MiddleName;
            account.LastName = model.LastName;
            account.Email = model.Email;
            account.PhoneNumber = model.PhoneNumber;

            if (account.Role.NormalizedName == "INSTRUCTOR")
            {
                var instructor = await context.Instructors
                    .Include(i => i.InstructorsCategories)
                    .FirstOrDefaultAsync(i => i.AccountId == account.Id);

                if (instructor == null)
                {
                    throw new NullReferenceException("Instructor cannot find!");
                }

                foreach (var category in model.Categories)
                {
                    if (category.IsMarked)
                    {
                        if (!instructor.InstructorsCategories.Any(ic => ic.CategoryId == category.Id))
                        {
                            await context.InstructorsCategories.AddAsync(new InstructorCategory()
                            {
                                CategoryId = category.Id,
                                Instructor = instructor
                            });
                        }
                    }
                }
            }

            await context.SaveChangesAsync();
        }

        private static string ConvertRoleNameToBulgarianLang(string roleName)
        {
            roleName = roleName.ToUpper();

            if (roleName == "STUDENT")
            {
                roleName = "Ученик";
            }
            else if (roleName == "INSTRUCTOR")
            {
                roleName = "Инструктор";
            }
            else
            {
                roleName = "Мениджър";
            }

            return roleName;
        }
    }
}
