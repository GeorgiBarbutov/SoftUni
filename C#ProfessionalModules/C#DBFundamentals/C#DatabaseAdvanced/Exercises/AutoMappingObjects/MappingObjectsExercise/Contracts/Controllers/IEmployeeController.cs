using MappingObjectsExercise.Dtos;
using System;
using System.Collections.Generic;

namespace MappingObjectsExercise.Contracts.Controllers
{
    public interface IEmployeeController
    {
        void AddEmployee(EmployeeDto employeeDto);

        void SetBirthday(int employeeId, DateTime date);

        void SetAddress(int employeeId, string address);

        EmployeeDto GetEmployeeInfo(int employeeId);

        EmployeePersonalInfoDto GetEmployeePersonalInfo(int employeeId);

        List<EmployeesOlderThanDto> ListEmployeesOlderThan(int age);
    }
}
