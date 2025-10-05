namespace Domain.Models
{
    public class Supplier
    {
        public Int32 Id { get; set; }

        public Int32 Nit { get; set; }

        public required String Name { get; set; }

        public required String Email { get; set; }

        public List<Service> Services { get; set; } = new();

        public List<CustomField> CustomFields { get; set; } = new();
    }
}