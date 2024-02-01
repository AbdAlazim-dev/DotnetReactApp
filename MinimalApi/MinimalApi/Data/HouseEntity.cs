namespace MinimalApi.Data
{
    public class HouseEntity
    {
        public int Id { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Photo { get; set; }
    }
}
