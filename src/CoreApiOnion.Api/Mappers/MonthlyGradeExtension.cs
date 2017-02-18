using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreApiOnion.Api.Contracts;
using CoreApiOnion.Core.Entities;

namespace CoreApiOnion.Api.Mappers
{
    public static class MonthlyGradeExtension
    {
        public static MonthlyGradeDto ToMonthlyGradeDto(this MonthlyGrade monthlyGrade)
        {
            return new MonthlyGradeDto
            {
                CustomerId = monthlyGrade.CustomerId,
                StaffId = monthlyGrade.StaffId,
                LetterScore = monthlyGrade.LetterScore,
                NumericalScore = monthlyGrade.NumericalScore,
                ParameterName = monthlyGrade.ParameterName,
                StartDate = monthlyGrade.StartDate,
                EndDate = monthlyGrade.StartDate
            };
        }

        public static IEnumerable<MonthlyGradeDto> ToMonthlyGradeDto(this IEnumerable<MonthlyGrade> monthlyGrades)
        {
            return monthlyGrades.Select(mg => mg.ToMonthlyGradeDto());
        }
    }
}
