namespace SimpleApi.Domain.Entities
{
    public class Product : Entity
    {
        public string Name { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public virtual Category? Category { get; set; }
    }
}
