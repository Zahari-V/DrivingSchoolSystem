namespace DrivingSchoolSystem.Core.Models.Common
{
    public class CategoryModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public bool IsMarked { get; set; }
    }
}
