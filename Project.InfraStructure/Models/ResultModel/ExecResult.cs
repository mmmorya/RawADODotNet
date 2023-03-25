using System;
namespace Project.InfraStructure.Models.ResultModel
{
    public class ExecResult
    {
        public bool IsSystemError { get; set; }
        public bool HasErrors { get; set; }
        public string Message { get; set; } = string.Empty;
        public IEnumerable<string> Errors { get; set; } = new List<string>();
    }

    public class ExecResult<T>
    {
        public T Data { get; set; }
        public int TotalRecords { get; set; }
        public bool IsSystemError { get; set; }
        public bool HasErrors { get; set; }
        public string Message { get; set; } = string.Empty;
        public IEnumerable<string> Errors { get; set; } = new List<string>();
    }
}
