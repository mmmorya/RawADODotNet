using System;
using Microsoft.Data.SqlClient;
using System.Collections;
using System.Data;

namespace Project.DataLayer.Contracts
{
    public interface IDAL
    {
        void Execute(string CommandName);
        void Execute(string CommandName, SqlParameter[] param);
        void Execute(string CommandName, Hashtable param);
        void ExecuteProcedure(string CommandName);
        void ExecuteProcedure(string CommandName, SqlParameter[] param);
        DataTable Get(string CommandName);
        DataTable Get(string CommandName, SqlParameter[] param);
        DataTable GetByProcedure(string CommandName);
        DataTable GetByProcedure(string CommandName, SqlParameter[] param);
        DataTable GetByProcedureAdapter(string CommandName, SqlParameter[] param);
        DataSet GetByProcedureAdapterDS(string CommandName, SqlParameter[] param);
        DataSet GetByProcedureAdapterDS(string CommandName);

        Task ExecuteAsync(string CommandName);
        Task ExecuteAsync(string CommandName, SqlParameter[] param);
        Task ExecuteAsync(string CommandName, Hashtable param);
        Task ExecuteProcedureAsync(string CommandName);
        Task ExecuteProcedureAsync(string CommandName, SqlParameter[] param);
        Task<DataTable> GetAsync(string CommandName);
        Task<DataTable> GetAsync(string CommandName, SqlParameter[] param);
        Task<DataTable> GetByProcedureAsync(string CommandName);
        Task<DataTable> GetByProcedureAsync(string CommandName, SqlParameter[] param);
        Task<DataTable> GetByProcedureAdapterAsync(string CommandName, SqlParameter[] param);
        Task<DataSet> GetByProcedureAdapterDSAsync(string CommandName, SqlParameter[] param);
    }
}

