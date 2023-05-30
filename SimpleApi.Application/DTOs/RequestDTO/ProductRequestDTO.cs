namespace SimpleApi.Application.DTOs.RequestDTO
{
    public class ProductRequestDTO
    {
        public string Name { get; set; } = string.Empty;

        public int CategoryId { get; set; }
    }
}
