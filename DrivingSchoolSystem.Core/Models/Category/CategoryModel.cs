using System.ComponentModel.DataAnnotations;

namespace DrivingSchoolSystem.Core.Models.Category
{
    public class CategoryModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        //public string ImageUrl { get; set; } = null!;

        public bool IsMarked { get; set; }
    }
}
