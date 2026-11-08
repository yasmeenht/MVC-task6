namespace mvc_task6.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();

    }
}
