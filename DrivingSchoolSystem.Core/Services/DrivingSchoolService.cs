using DrivingSchoolSystem.Core.Contracts;
using DrivingSchoolSystem.Core.Models.Category;
using DrivingSchoolSystem.Core.Models.DrivingSchool;
using DrivingSchoolSystem.Infrastructure.Data;
using DrivingSchoolSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace DrivingSchoolSystem.Core.Services
{
    public class DrivingSchoolService : IDrivingSchoolService
    {
        private readonly ApplicationDbContext context;

        public DrivingSchoolService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task EditInfoAsync(DrivingSchoolInfoModel model)
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
                else if(isEducationCategory)
                {
                    var educationCategory = drivingSchool.EducationCategories
                        .First(dsc => dsc.CategoryId == category.Id);

                    context.DrivingSchoolsCategories.Remove(educationCategory);
                }
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DrivingSchoolModel>> GetAll()
        {
            return await context.DrivingSchools
                .AsNoTracking()
                .Select(ds => new DrivingSchoolModel
                {
                    Id = ds.Id,
                    Name = ds.Name
                })
                .ToListAsync();
        }

        public async Task<DrivingSchoolInfoModel> GetInfoByIdAsync(int drivingSchoolId)
        {
            var drivingSchool = await context.DrivingSchools
                .AsNoTracking()
                .Include(ds => ds.EducationCategories)
                .ThenInclude(ec => ec.Category)
                .FirstAsync(ds => ds.Id == drivingSchoolId);

            var model = new DrivingSchoolInfoModel()
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
                    //ImageUrl = ec.Category.ImageUrl
                }).ToList()
            };

            return model;
        }

        public async Task<string> GetNameByIdAsync(int drivingSchoolId)
        {
            var drivingSchool = await context.DrivingSchools
                .AsNoTracking()
                .FirstAsync(ds => ds.Id == drivingSchoolId);

            return drivingSchool.Name;
        }
        public async Task<List<CategoryModel>> MarkDrivingSchoolCategoriesAsync(IEnumerable<CategoryModel> drivingSchoolCategories)
        {
            var categories = await context.Categories
               .AsNoTracking()
               .Select(c => new CategoryModel()
               {
                   Id = c.Id,
                   Name = c.Name
                   //ImageUrl = c.ImageUrl
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
