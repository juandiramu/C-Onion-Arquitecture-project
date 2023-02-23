

namespace Dealership_Domain
{
    public class Advisor: Person
    {
        public double? Salary { get; set; }
        public IEnumerable<Bill>? Bills { get; set; }

        public void create(string? name, string? email, string? phone, double? salary)
        {
            Id= new Guid();
            Name= name;
            Email= email;
            Phone= phone;
            Salary= salary;
            CreationDate= DateTime.Now;
            IsDeleted= false;
        }
        public void edit(string? name, string? email, string? phone, double? salary)
        {
            Name= name;
            Email= email;
            Salary = salary; 
            Phone= phone;
        }

    }
}
