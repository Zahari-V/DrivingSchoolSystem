﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrivingSchoolSystem.Infrastructure.Data.Models
{
    public class User : IdentityUser
    {
        [StringLength(400)]
        public string ImageUrl { get; set; } = null!;

        public Guid AccountId { get; set; }

        [ForeignKey(nameof(AccountId))]
        public Account Account { get; set; } = null!;
    }
}
