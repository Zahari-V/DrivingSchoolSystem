using DrivingSchoolSystem.Core.Contracts;
using DrivingSchoolSystem.Core.Models.DrivingSchool;
using DrivingSchoolSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSchoolSystem.Core.Services
{
    public class DrivingSchoolService : IDrivingSchoolService
    {
        private readonly ApplicationDbContext context;

        public DrivingSchoolService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public IEnumerable<DrivingSchoolModel> GetAllDrivingSchools()
        {
            return context.DrivingSchools
                .Select(ds => new DrivingSchoolModel
                {
                    Id = ds.Id,
                    Name = ds.Name
                })
                .AsEnumerable();
        }

        public async Task<string> GetDrivingSchoolNameAsync(int drivingSchoolId)
        {
            var drivingSchool = await context.DrivingSchools.FindAsync(drivingSchoolId);

            if (drivingSchool == null)
            {
                throw new NullReferenceException($"Driving School with this id {drivingSchoolId} cannot be find.");
            }

            return drivingSchool.Name;
        }
    }
}
