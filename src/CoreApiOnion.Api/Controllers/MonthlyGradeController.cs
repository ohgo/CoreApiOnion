using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreApiOnion.Api.Mappers;
using CoreApiOnion.Core.Entities;
using CoreApiOnion.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiOnion.Api.Controllers
{
    [Route("api/[controller]")]
    public class MonthlyGradeController : Controller
    {
        private readonly IMonthlyGradeRepository _monthlyGradeRepository;

        public MonthlyGradeController(IMonthlyGradeRepository monthlyGradeRepository)
        {
            _monthlyGradeRepository = monthlyGradeRepository;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="customerId">Customer Id in Guid format</param>
        /// <returns></returns>
        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetByCustomer(Guid customerId)
        {
            var monthlyGrades = await _monthlyGradeRepository.GetByCustomer(customerId);

            return Ok(monthlyGrades.ToMonthlyGradeDto());
        }

        [HttpGet("staff/{staffId}")]
        public async Task<IActionResult> GetByStaff(Guid staffId)
        {
            var monthlyGrades = await _monthlyGradeRepository.GetByStaff(staffId);

            return Ok(monthlyGrades.ToMonthlyGradeDto());
        }
    }
}
