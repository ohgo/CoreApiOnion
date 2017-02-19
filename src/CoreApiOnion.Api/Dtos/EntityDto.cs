namespace CoreApiOnion.Api.Models
{
    public class EntityDto
    {
        public EntityDto(int entityId)
        {
            EntityId = entityId;
        }

        public int EntityId { get; private set; }
    }
}
