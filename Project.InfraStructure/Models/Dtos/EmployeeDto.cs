using System;
namespace Project.InfraStructure.Models.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;

        public string? Address { get; set; }

        public int DepartmentId { get; set; }

        public DepartmentDto MyDepartmentDto { get; set; } = new DepartmentDto();
    }
}

