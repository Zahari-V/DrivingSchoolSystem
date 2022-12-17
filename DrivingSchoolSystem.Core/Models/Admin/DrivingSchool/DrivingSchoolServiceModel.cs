using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolSystem.Core.Models.Admin.DrivingSchool
{
    public class DrivingSchoolServiceModel
    {
        public DrivingSchoolServiceModel()
        {
            DrivingSchool = new DrivingSchoolModel();
        }

        [Required]
        public DrivingSchoolModel DrivingSchool { get; set; } = null!;

        public ManagerModel? Manager { get; set; }
    }
}
