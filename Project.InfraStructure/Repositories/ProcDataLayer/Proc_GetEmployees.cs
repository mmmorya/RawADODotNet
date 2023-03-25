using System;
using System.Data;
using Microsoft.Data.SqlClient;
using Project.DataLayer.Contracts;
using Project.InfraStructure.Models.Dtos;
using Project.InfraStructure.Models.RequestModel;
using Project.InfraStructure.Models.ResultModel;

namespace Project.InfraStructure.Repositories.ProcDataLayer
{
    public class Proc_GetEmployees : IProcedure
    {
        private readonly IDAL _dAL;

        public Proc_GetEmployees(IDAL dAL) => _dAL = dAL;

        public object Call(object obj)
        {
            var request = (CommonRequestModel)obj;
            var response = new ExecResult<IEnumerable<EmployeeDto>>();
            var employeeList = new List<EmployeeDto>();
            SqlParameter[] param = {
                    new SqlParameter("@Id", request.Id)
            };
            try
            {
                var dt = _dAL.GetByProcedure(GetName(), param);
                if (dt.Rows.Count > 0)
                {
                    response.HasErrors = Convert.ToBoolean(dt.Rows[0][0]);

                    foreach (DataRow dr in dt.Rows)
                    {
                        employeeList.Add(new EmployeeDto
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            FirstName = dr["FirstName"].ToString(),
                            LastName = dr["LastName"].ToString(),
                            Email = dr["Email"].ToString(),
                            Address = dr["Address"].ToString(),
                            Phone = dr["Phone"].ToString(),
                            DepartmentId = Convert.ToInt32(dr["DepartmentId"]),
                            MyDepartmentDto = new DepartmentDto()
                            {
                                Id = Convert.ToInt32(dr["DepartmentId"]),
                                DepartmentName = dr["DepartmentName"].ToString()
                            }
                        });
                    }

                    response.Data = employeeList;
                    //if (response.HasErrors)
                    //    response.Errors = new string[] { dt.Rows[0]["Msg"] is DBNull ? string.Empty : Convert.ToString(dt.Rows[0]["Msg"]) ?? string.Empty };
                    //else
                    //    response.Message = dt.Rows[0]["Msg"] is DBNull ? string.Empty : Convert.ToString(dt.Rows[0]["Msg"]) ?? string.Empty;
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

