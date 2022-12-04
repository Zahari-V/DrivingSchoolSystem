using DrivingSchoolSystem.Core.Models.Category;

namespace DrivingSchoolSystem.Core.Models.DrivingSchool
{
    public class DrivingSchoolInfoModel : DrivingSchoolModel
    {
        public string Town { get; set; } = null!;

        public string Address { get; set; } = null!;

        public string? PhoneContact { get; set; }

        public List<CategoryModel> EducationCategories { get; set; } = new List<CategoryModel>();
    }
}
