using DrivingSchoolSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSchoolSystem.Core.Contracts
{
    public interface IDrivingSchoolService
    {
        IEnumerable<DrivingSchoolModel> GetAllDrivingSchools();
    }
}
