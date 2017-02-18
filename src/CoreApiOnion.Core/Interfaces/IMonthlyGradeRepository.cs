using CoreApiOnion.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiOnion.Core.Interfaces
{
    public interface IMonthlyGradeRepository
    {
        Task<IEnumerable<MonthlyGrade>> GetByCustomer(Guid CustomerId);

        Task<IEnumerable<MonthlyGrade>> GetByStaff(Guid StaffId);
    }
}
