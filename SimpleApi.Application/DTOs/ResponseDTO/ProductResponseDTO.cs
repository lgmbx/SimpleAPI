namespace SimpleApi.Application.DTOs.RequestDTO
{
    public class ProductResponseDTO
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public CategoryResponseDTO Category { get; set; } = new CategoryResponseDTO();
    }
}
