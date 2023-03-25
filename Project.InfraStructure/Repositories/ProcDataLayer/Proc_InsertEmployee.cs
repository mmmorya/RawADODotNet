using System;
using Microsoft.Data.SqlClient;
using Project.DataLayer.Contracts;
using Project.DataLayer.DataAccessLayer;
using Project.InfraStructure.Models.Dtos;
using Project.InfraStructure.Models.ResultModel;

namespace Project.InfraStructure.Repositories.ProcDataLayer
{
    public class Proc_InsertEmployee : IProcedure
    {
        private readonly IDAL _dAL;

        public Proc_InsertEmployee(IDAL dAL) => _dAL = dAL;

        public object Call(object obj)
        {
            var request = (EmployeeDto)obj;
            var response = new ExecResult();
            SqlParameter[] param = {
                    new SqlParameter("@FirstName", request.FirstName),
                    new SqlParameter("@LastName", request.LastName),
                    new SqlParameter("@Email", request.Email),
                    new SqlParameter("@Phone", request.Phone),
                    new SqlParameter("@Address", request.Address),
                    new SqlParameter("@DepartmentId", request.DepartmentId)
            };
            try
            {
                var dt = _dAL.GetByProcedure(GetName(), param);
                if (dt.Rows.Count > 0)
                {
                    response.HasErrors = Convert.ToBoolean(dt.Rows[0][0]);
                    if (response.HasErrors)
                        response.Errors = new string[] { dt.Rows[0]["Msg"] is DBNull ? string.Empty : Convert.ToString(dt.Rows[0]["Msg"]) ?? string.Empty };
                    else
                        response.Message = dt.Rows[0]["Msg"] is DBNull ? string.Empty : Convert.ToString(dt.Rows[0]["Msg"]) ?? string.Empty;
                }
            }
            catch (Exception ex)
            {
                response.HasErrors = true;
                response.IsSystemError = true;
                response.Errors = new string[] { ex.Message };
            }

            return response;
        }

        public object Call()
        {
            throw new NotImplementedException();
        }

        public string GetName() => "InsertEmployee";
    }
}

