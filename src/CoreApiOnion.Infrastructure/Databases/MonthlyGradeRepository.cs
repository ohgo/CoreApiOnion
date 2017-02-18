using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using CoreApiOnion.Core.Entities;
using CoreApiOnion.Core.Interfaces;

namespace CoreApiOnion.Infrastructure.Databases
{
    public class MonthlyGradeRepository : IMonthlyGradeRepository
    {
        public async Task<IEnumerable<MonthlyGrade>> GetByCustomer(Guid customerId)
        {
            return await Task.FromResult(_monthlyGrades.Where(mg => mg.CustomerId == customerId));
        }

        public async Task<IEnumerable<MonthlyGrade>> GetByStaff(Guid staffId)
        {
            return await Task.FromResult(_monthlyGrades.Where(mg => mg.StaffId == staffId));
        }

        private readonly List<MonthlyGrade> _monthlyGrades = new List<MonthlyGrade>
        {
            new MonthlyGrade
            {
                CustomerId = new Guid("64BA2F4A-51A6-4C00-A9F6-B9BB7E6DF03C"),
                StaffId = new Guid("D7CB15A4-49AC-4589-A95C-2EDCC69E5543"),
                LetterScore = "A",
                NumericalScore = 9m,
                ParameterName = "Idling",
                StartDate = new DateTime(2017, 1, 1),
                EndDate = new DateTime(2017, 1, 31)
            },
            new MonthlyGrade
            {
                CustomerId = new Guid("64BA2F4A-51A6-4C00-A9F6-B9BB7E6DF03C"),
                StaffId = new Guid("F985C1E1-F00D-4B01-AD57-7DDB8C4EF80D"),
                LetterScore = "E",
                NumericalScore = 2.9m,
                ParameterName = "Idling",
                StartDate = new DateTime(2017, 2, 1),
                EndDate = new DateTime(2017, 2, 28)
            },
            new MonthlyGrade
            {
                CustomerId = new Guid("64BA2F4A-51A6-4C00-A9F6-B9BB7E6DF03C"),
                StaffId = new Guid("D7CB15A4-49AC-4589-A95C-2EDCC69E5543"),
                LetterScore = "C",
                NumericalScore = 6.5m,
                ParameterName = "Speeding",
                StartDate = new DateTime(2017, 1, 1),
                EndDate = new DateTime(2017, 1, 31)
            }
        };
    }
}
