

namespace Dealership_Domain
{
    public class Car: Entity<Guid>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public Color? Color { get; set; }
        public string? Potencia { get; set; }
        public IEnumerable <Bill>? Bills { get; set; }
        public bool? IsSold { get; set; }
        public double? SalePrice { get; set; }

        public void Create(string? name, string? description, string? brand, string? model, string? potencia, Color? color, double? price)
        {
            Id= Guid.NewGuid();
            Name = name;
            Description = description;
            Brand = brand;
            Model = model;
            Potencia= potencia;
            CreationDate= DateTime.Now;
            Color = color;
            IsDeleted= false;
            IsSold= false;
            SalePrice = price;
        }

        public void edit (string? description, double? price)
        {
            Description = description;
            SalePrice= price;
        }
    }
}
