using System;
namespace Project.InfraStructure.Models.RequestModel
{
    public class CommonRequestModel
    {
        public int Id { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public string SearchTerm { get; set; }
        public string UserId { get; set; } = string.Empty;
    }
}

