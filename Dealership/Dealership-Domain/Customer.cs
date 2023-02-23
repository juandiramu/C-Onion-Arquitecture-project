
namespace Dealership_Domain
{
    public class Customer : Person
    {
        public IEnumerable<Bill>? Bills { get; set; } 
        public void create(string? name, string? email, string? phone)
        {
            Id = new Guid();
            Name = name;
            Email = email;
            Phone = phone;
            CreationDate = DateTime.Now;
            IsDeleted = false;
        }
        public void edit(string? name, string? email, string? phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }
    }
}
