namespace EmployeeAdminPortal.Models.Entities
{
    public class Employee
    {
        // Guid : globally unique identifier. 32 char hexadecimal string
        public Guid Id { get; set; }
        // required: ensures that when the object of the class is created, the attribute cannot be set to null i.e it must have a value.
        public required string Name { get; set; }
        public required string Email { get; set; }
        // ? indicates, the attribute may or may have a value i.e it could be nullable.
        public string? Phone { get; set; }
        public decimal Salary { get; set; }
    }
}
