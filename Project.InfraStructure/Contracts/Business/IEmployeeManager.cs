using System;
using Project.InfraStructure.Models.Dtos;
using Project.InfraStructure.Models.RequestModel;
using Project.InfraStructure.Models.ResultModel;

namespace Project.InfraStructure.Contracts.Business
{
    public interface IEmployeeManager
    {

        ExecResult CreateEmployee(EmployeeDto employeeDto);
        ExecResult<IEnumerable<EmployeeDto>> Get(CommonRequestModel commonRequestModel);
        ExecResult<EmployeeDto> Get(int id);
        ExecResult Edit(EmployeeDto employeeDto);
        ExecResult Delete(int id);
    }
}

