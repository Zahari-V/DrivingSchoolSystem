﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrivingSchoolSystem.Infrastructure.Data.Models
{
    public class InstructorCategory
    {
        [Required]
        public int InstructorId { get; set; }

        [ForeignKey(nameof(InstructorId))]
        public Instructor Instructor { get; set; } = null!;

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;
    }
}
