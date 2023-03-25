using System;
namespace Project.DataLayer.Contracts
{
    public interface IProcedure
    {
        string GetName();
        object Call(object obj);
        object Call();
    }
}

