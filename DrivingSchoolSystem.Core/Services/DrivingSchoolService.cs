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

        public async Task EditProfileAsync(DrivingSchoolInfoModel model)
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

        public IEnumerable<DrivingSchoolModel> GetAllDrivingSchools()
        {
            return context.DrivingSchools
                .AsNoTracking()
                .Select(ds => new DrivingSchoolModel
                {
                    Id = ds.Id,
                    Name = ds.Name
                })
                .AsEnumerable();
        }

        public async Task<DrivingSchoolInfoModel> GetDrivingSchoolInfoByIdAsync(int drivingSchoolId)
        {
            var drivingSchool = await context.DrivingSchools
                .Include(ds => ds.EducationCategories)
                .ThenInclude(ec => ec.Category)
                .FirstOrDefaultAsync(ds => ds.Id == drivingSchoolId);

            if (drivingSchool == null)
            {
                throw new NullReferenceException("Грешка при намирането на Автошколата!");
            }

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

        public async Task<string> GetDrivingSchoolNameByIdAsync(int drivingSchoolId)
        {
            var drivingSchool = await context.DrivingSchools.FindAsync(drivingSchoolId);

            if (drivingSchool == null)
            {
                throw new NullReferenceException($"Driving School with this id {drivingSchoolId} cannot be find.");
            }

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
