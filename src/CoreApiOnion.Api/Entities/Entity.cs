namespace CoreApiOnion.Api.Entities
{
    public class Entity
    {
        public Entity(int entityId)
        {
            EntityId = entityId;
        }

        public int EntityId { get; private set; }
    }
}
