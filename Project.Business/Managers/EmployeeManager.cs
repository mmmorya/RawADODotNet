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
            var result = (ExecResult<IEnumerable<EmployeeDto>>)proc.Call(new CommonRequestModel()
            {
                Id = 0
            });
            return result;
        }

        public ExecResult CreateEmployee(EmployeeDto employeeDto)
        {
            var proc = new Proc_InsertEmployee(_iDAL);

            return (ExecResult)proc.Call(employeeDto);
        }
    }
}

