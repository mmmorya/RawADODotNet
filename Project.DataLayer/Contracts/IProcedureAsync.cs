using System;
namespace Project.DataLayer.Contracts
{
    public interface IProcedureAsync
    {
        Task<object> Call(object obj);
        Task<object> Call();
        string GetName();
    }
}

