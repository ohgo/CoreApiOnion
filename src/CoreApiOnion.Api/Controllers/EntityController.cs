using System.Threading.Tasks;
using CoreApiOnion.Api.Dtos;
using CoreApiOnion.Api.Entities;
using CoreApiOnion.Api.Interfaces;
using CoreApiOnion.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreApiOnion.Api.Controllers
{
    [Route("api/[controller]")]
    public class EntityController : Controller
    {
        private readonly IService _service;

        public EntityController(IService service)
        {
            _service = service;
        }

        /// <summary>
        /// Example controller
        /// </summary>
        /// <param name="entityId">Example parameter</param>
        /// <returns></returns>
        [HttpGet("{entityId}")]
        [ProducesResponseType(typeof(EntityDto), 200)]
        [ProducesResponseType(typeof(void), 500)]
        public async Task<IActionResult> Get(int entityId)
        {
            return await Task.FromResult(Ok(new Entity(entityId).ToEntityDto()));
        }
    }
}
