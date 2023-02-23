

namespace Dealership_Domain
{
    public class Bill: Entity<Guid>
    {
        public Guid? IdAsvisor { get; set; }
        public Advisor? Advisor { get; set; }
        public Guid? IdCustomer { get; set; }
        public Customer? Customer { get; set; }
        public Guid? IdCar { get; set; }
        public Car? Car { get; set; }
        public double ?Total { get; set; }

        public void create(Guid? idAdvisor, Guid? idCustomer,Guid? idCar, double? total)
        {
            Id = new Guid();
            IdAsvisor = idAdvisor;
            IdCustomer = idCustomer;
            IdCar = idCar;
            Total = total;
            CreationDate= DateTime.Now;
            IsDeleted= false;
        }
        public void edit(Guid? idCustomer, Guid? idCar, double? total)
        {
            IdCustomer= idCustomer;
            IdCar= idCar;
            Total = total;
        }
    }
}
