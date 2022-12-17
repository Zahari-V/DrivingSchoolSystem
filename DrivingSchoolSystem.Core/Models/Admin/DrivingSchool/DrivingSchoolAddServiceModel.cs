using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolSystem.Core.Models.Admin.DrivingSchool
{
    public class DrivingSchoolAddServiceModel
    {
        public DrivingSchoolAddServiceModel()
        {
            DrivingSchool = new DrivingSchoolModel();
        }

        [Required]
        public DrivingSchoolModel DrivingSchool { get; set; } = null!;

        [Required]
        public ManagerModel Manager { get; set; } = null!;
    }
}
