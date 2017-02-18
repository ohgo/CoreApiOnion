using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreApiOnion.Core.Entities;
using CoreApiOnion.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiOnion.Api.Controllers
{
    [Route("api/[controller]")]
    public class MonthlyAggregationController : Controller
    {
        private readonly IMonthlyGradeRepository _monthlyGradeRepository;
        private ITripGradeRepository _tripGradeRepository;
        private IAggregationService _aggregationService;

        public MonthlyAggregationController(IMonthlyGradeRepository monthlyGradeRepository, ITripGradeRepository tripGradeRepository, IAggregationService aggregationService)
        {
            _monthlyGradeRepository = monthlyGradeRepository;
            _tripGradeRepository = tripGradeRepository;
            _aggregationService = aggregationService;
        }

        [HttpPost]
        public async Task<IActionResult> AggregateCustomer()
        {
            return await Task.FromResult(Ok());
        }
    }
}
