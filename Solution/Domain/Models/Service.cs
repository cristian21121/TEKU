namespace Domain.Models
{
    public class Service
    {
        public Int32 Id { get; set; }

        public Int32 SupplierId { get; set; }

        public required String Name { get; set; }

        public Decimal HourValue { get; set; }

        //Lo ideal seria guardar un ID pero en API que usare se guia por los codigos de cada pais
        public List<Country> Countries { get; set; } = new();
    }
}