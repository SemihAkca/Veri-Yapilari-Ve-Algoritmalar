namespace Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }

        public Employee()
        {
            
        }

        public override string ToString()
        {
            return $"Id: {Id,-5} FirstName: {FirstName,-15} LastName: {LastName,-15} Salary => {Salary,-15} ";
        }
    }
}