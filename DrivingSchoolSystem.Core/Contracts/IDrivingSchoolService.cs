﻿using DrivingSchoolSystem.Core.Models.Category;
using DrivingSchoolSystem.Core.Models.DrivingSchool;

namespace DrivingSchoolSystem.Core.Contracts
{
    public interface IDrivingSchoolService
    {
        IEnumerable<DrivingSchoolModel> GetAllDrivingSchools();

        Task<string> GetDrivingSchoolNameByIdAsync(int drivingSchoolId);

        Task<DrivingSchoolInfoModel> GetDrivingSchoolInfoByIdAsync(int drivingSchoolId);

        Task<List<CategoryModel>> 
            MarkDrivingSchoolCategoriesAsync(IEnumerable<CategoryModel> drivingSchoolCategories);

        Task EditProfileAsync(DrivingSchoolInfoModel model);
    }
}
