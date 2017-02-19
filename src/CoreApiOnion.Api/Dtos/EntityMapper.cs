using CoreApiOnion.Api.Entities;
using CoreApiOnion.Api.Models;

namespace CoreApiOnion.Api.Dtos
{
    /// <summary>
    /// Either injected mapper class or static extension method
    /// </summary>
    public static class EntityExtension
    {
        public static EntityDto ToEntityDto(this Entity entity)
        {
            return new EntityDto(entity.EntityId);
        }
    }
}
