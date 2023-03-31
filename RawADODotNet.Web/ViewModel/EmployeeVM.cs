using System;
using System.ComponentModel.DataAnnotations;
using Project.InfraStructure.Models.Dtos;

namespace RawADODotNet.Web.ViewModel
{
    public class EmployeeVM : BaseViewModel<EmployeeDto>
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Phone { get; set; } = string.Empty;

        public string? Address { get; set; }

        [Required]
        public int DepartmentId { get; set; }
    }
}

