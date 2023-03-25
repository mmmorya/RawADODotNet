using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Project.DataLayer.Contracts;
using Project.InfraStructure.Models.Dtos;
using Project.InfraStructure.Models.RequestModel;
using Project.InfraStructure.Models.ResultModel;

namespace Project.InfraStructure.Repositories.ProcDataLayer
{
    public class Proc_GetEmployeeById : IProcedure
    {
        private readonly IDAL _dAL;

        public Proc_GetEmployeeById(IDAL dAL) => _dAL = dAL;

        public object Call(object obj)
        {
            var request = (CommonRequestModel)obj;
            var response = new ExecResult<EmployeeDto>();
            SqlParameter[] param = {
                    new SqlParameter("@Id", request.Id)
            };
            try
            {
                var dt = _dAL.GetByProcedure(GetName(), param);
                if (dt.Rows.Count > 0)
                {
                    response.HasErrors = Convert.ToBoolean(dt.Rows[0][0]);
                    response.Data = new EmployeeDto
                    {
                        Id = Convert.ToInt32(dt.Rows[0]["Id"]),
                        FirstName = dt.Rows[0]["FirstName"].ToString(),
                        LastName = dt.Rows[0]["LastName"].ToString(),
                        Email = dt.Rows[0]["Email"].ToString(),
                        Address = dt.Rows[0]["Address"].ToString(),
                        Phone = dt.Rows[0]["Phone"].ToString(),
                        DepartmentId = Convert.ToInt32(dt.Rows[0]["DepartmentId"]),
                        MyDepartmentDto = new DepartmentDto()
                        {
                            Id = Convert.ToInt32(dt.Rows[0]["DepartmentId"]),
                            DepartmentName = dt.Rows[0]["DepartmentName"].ToString()
                        }
                    };
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

        public string GetName() => "Proc_GetEmployees";
    }
}

