using DrivingSchoolSystem.Core.Constants;
using DrivingSchoolSystem.Core.Contracts.Admin;
using DrivingSchoolSystem.Core.Models.Admin.DrivingSchool;
using DrivingSchoolSystem.Core.Models.Common;
using DrivingSchoolSystem.Infrastructure.Data;
using DrivingSchoolSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DrivingSchoolSystem.Core.Services.Admin
{
    public class DrivingSchoolService : IDrivingSchoolService
    {
        private readonly ApplicationDbContext context;

        public DrivingSchoolService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task AddAsync(DrivingSchoolAddServiceModel model)
        {
            if (await context.DrivingSchools.AnyAsync(ds => ds.Name == model.DrivingSchool.Name))
            {
                throw new ArgumentException("Already has driving school with this name!");
            }

            var drivingSchool = new DrivingSchool()
            {
                Name = model.DrivingSchool.Name,
                Address = model.DrivingSchool.Address,
                Town = model.DrivingSchool.Town,
                PhoneContact = model.DrivingSchool.PhoneContact
            };

            await context.DrivingSchools.AddAsync(drivingSchool);

            var drivingSchoolCategories = model.DrivingSchool.EducationCategories
                .Where(ec => ec.IsMarked)
                .Select(ec => new DrivingSchoolCategory()
                {
                    CategoryId = ec.Id,
                    DrivingSchool = drivingSchool
                });

            await context.DrivingSchoolsCategories.AddRangeAsync(drivingSchoolCategories);

            var account = new Account()
            {
                FirstName = model.Manager.FirstName,
                MiddleName = model.Manager.MiddleName,
                LastName = model.Manager.LastName,
                Email = model.Manager.Email,
                NormalizedEmail = model.Manager.Email.ToUpper(),
                PhoneNumber = model.Manager.PhoneNumber,
                RoleId = context.Roles.First(r => r.NormalizedName == RoleConstant.NormalizedManager).Id,
                DrivingSchool = drivingSchool
            };

            await context.Accounts.AddAsync(account);

            var manager = new Manager()
            {
                Account = account
            };

            await context.Managers.AddAsync(manager);

            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int drivingSchoolId)
        {
            var drivingSchool = await context.DrivingSchools
                                    .Include(ds => ds.Accounts)
                                    .ThenInclude(a => a.Role)
                                    .FirstOrDefaultAsync(ds => ds.Id == drivingSchoolId);

            if (drivingSchool == null)
            {
                throw new NullReferenceException("Driving School cannot find!");
            }

            drivingSchool.IsDeleted = true;

            foreach (var account in drivingSchool.Accounts)
            {
                account.IsDeleted = true;
            }

            var managerAccountId = drivingSchool.Accounts
                .First(a => a.Role.NormalizedName == RoleConstant.NormalizedManager).Id;

            var manager = await context.Managers
                .Include(m => m.Courses)
                .ThenInclude(c => c.StudentCards)
                .FirstAsync(m => 
                    m.AccountId == managerAccountId);

            foreach (var course in manager.Courses)
            {
                course.IsDeleted = true;

                foreach (var studentCard in course.StudentCards)
                {
                    studentCard.IsDeleted = true;
                }
            }

            await context.SaveChangesAsync();
        }

        public async Task EditAsync(DrivingSchoolModel model)
        {
            var drivingSchool = await context.DrivingSchools
                .Include(ds => ds.EducationCategories)
                .FirstAsync(ds => ds.Id == model.Id);

            drivingSchool.Name = model.Name;
            drivingSchool.Town = model.Town;
            drivingSchool.PhoneContact = model.PhoneContact;
            drivingSchool.Address = model.Address;

            foreach (var category in model.EducationCategories)
            {
                var isEducationCategory = drivingSchool
                    .EducationCategories.Any(ec => ec.CategoryId == category.Id);

                if (category.IsMarked)
                {
                    if (!isEducationCategory)
                    {
                        var drivingSchoolCategory = new DrivingSchoolCategory()
                        {
                            DrivingSchoolId = drivingSchool.Id,
                            CategoryId = category.Id
                        };

                        await context.DrivingSchoolsCategories.AddAsync(drivingSchoolCategory);
                    }
                }
                else if (isEducationCategory)
                {
                    var educationCategory = drivingSchool.EducationCategories
                        .First(dsc => dsc.CategoryId == category.Id);

                    context.DrivingSchoolsCategories.Remove(educationCategory);
                }
            }

            await context.SaveChangesAsync();
        }

        public IEnumerable<DrivingSchoolModel> GetAll()
        {
            return context.DrivingSchools
                .AsNoTracking()
                .Where(ds => !ds.IsDeleted)
                .Select(ds => new DrivingSchoolModel
                {
                    Id = ds.Id,
                    Name = ds.Name,
                    Town = ds.Town,
                    Address = ds.Address,
                    PhoneContact = ds.PhoneContact
                });
        }

        public async Task<List<CategoryModel>> GetCategoriesAsync()
        {
            return await context.Categories
                .AsNoTracking()
                .Select(ec => new CategoryModel()
                {
                    Id = ec.Id,
                    Name = ec.Name,
                    IsMarked = false
                })
                .ToListAsync();
        }

        public async Task<DrivingSchoolModel> GetByIdAsync(int drivingSchoolId)
        {
            var drivingSchool = await context.DrivingSchools
                .AsNoTracking()
                .Include(ds => ds.EducationCategories)
                .ThenInclude(ec => ec.Category)
                .FirstAsync(ds => ds.Id == drivingSchoolId);

            var model = new DrivingSchoolModel()
            {
                Id = drivingSchool.Id,
                Name = drivingSchool.Name,
                Town = drivingSchool.Town,
                Address = drivingSchool.Address,
                PhoneContact = drivingSchool.PhoneContact,
                EducationCategories = drivingSchool.EducationCategories
                .Select(ec => new CategoryModel()
                {
                    Id = ec.Category.Id,
                    Name = ec.Category.Name
                }).ToList()
            };

            return model;
        }

        public async Task<List<CategoryModel>> MarkCategoriesAsync(IEnumerable<CategoryModel> drivingSchoolCategories)
        {
            var categories = await context.Categories
               .AsNoTracking()
               .Select(c => new CategoryModel()
               {
                   Id = c.Id,
                   Name = c.Name
               }).ToListAsync();

            foreach (var category in categories)
            {
                category.IsMarked = drivingSchoolCategories
                    .Any(dsc => dsc.Id == category.Id);
            }

            return categories;
        }
    }
}
