using System;
using Project.DataLayer.Contracts;
using Project.InfraStructure.Contracts.Business;
using Project.InfraStructure.Models.Dtos;
using Project.InfraStructure.Models.RequestModel;
using Project.InfraStructure.Models.ResultModel;
using Project.InfraStructure.Repositories.ProcDataLayer;

namespace Project.Business.Managers
{
    public class EmployeeManager : IEmployeeManager
    {
        public readonly IDAL _iDAL;
        public EmployeeManager(IDAL iDAL)
        {
            _iDAL = iDAL;
        }

        public ExecResult<IEnumerable<EmployeeDto>> Get()
        {
            var proc = new Proc_GetEmployees(_iDAL);

            //for (int i = 0; i < 100; i++)
            //{
            //    var _ = new Proc_InsertEmployee(_iDAL);

            //    var resData = (ExecResult)_.Call(new EmployeeDto()
            //    {
            //        FirstName = G(),
            //        LastName = G(),
            //        Phone = G(),
            //        Email = $"{G()}@{G()}.{G()}",
            //        Address = G()
            //    });
            //}


            var result = (ExecResult<IEnumerable<EmployeeDto>>)proc.Call(new CommonRequestModel()
            {
                Id = 0
            });
            if (result.Data == null)
                result.Data = new List<EmployeeDto>();
            return result;
        }

        private string G()
        {
            return Guid.NewGuid().ToString().Split('-').First();
        }

        public ExecResult<EmployeeDto> Get(int id)
        {
            var proc = new Proc_GetEmployeeById(_iDAL);
            var result = (ExecResult<EmployeeDto>)proc.Call(new CommonRequestModel()
            {
                Id = id
            });
            return result;
        }

        public ExecResult CreateEmployee(EmployeeDto employeeDto)
        {
            var proc = new Proc_InsertEmployee(_iDAL);

            return (ExecResult)proc.Call(employeeDto);
        }

        public ExecResult Edit(EmployeeDto employeeDto)
        {
            var proc = new Proc_EditEmployee(_iDAL);

            return (ExecResult)proc.Call(employeeDto);
        }

        public ExecResult Delete(int id)
        {
            var proc = new Proc_DeleteEmployee(_iDAL);
            var result = (ExecResult)proc.Call(new CommonRequestModel()
            {
                Id = id
            });
            return result;
        }
    }
}

