using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MappingObjectsExercise.Contracts.Controllers;
using MappingObjectsExercise.Data;
using MappingObjectsExercise.Data.Models;
using MappingObjectsExercise.Dtos;

namespace MappingObjectsExercise.Controllers
{
    public class EmployeeController : IEmployeeController
    {
        private const string EMPLOYEE_NOT_FOUND = "Employee not found";

        private MappingObjectsExerciseContext context;
        private IMapper mapper;

        public EmployeeController(MappingObjectsExerciseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public void AddEmployee(EmployeeDto employeeDto)
        {
            var employee = this.mapper.Map<Employee>(employeeDto);

            context.Employees.Add(employee);

            context.SaveChanges();
        }

        public EmployeePersonalInfoDto GetEmployeePersonalInfo(int employeeId)
        {
            var employee = this.context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException(EMPLOYEE_NOT_FOUND);
            }

            return this.mapper.Map<EmployeePersonalInfoDto>(employee);
        }

        public EmployeeDto GetEmployeeInfo(int employeeId)
        {
            var employee = this.context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException(EMPLOYEE_NOT_FOUND);
            }

            var employeeDto = this.mapper.Map<EmployeeDto>(employee);

            return employeeDto;
        }

        public void SetAddress(int employeeId, string address)
        {
            var employee = this.context.Employees.Find(employeeId);

            if(employee == null)
            {
                throw new ArgumentException(EMPLOYEE_NOT_FOUND);
            }

            employee.Address = address;

            context.SaveChanges();
        }

        public void SetBirthday(int employeeId, DateTime date)
        {
            var employee = this.context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException(EMPLOYEE_NOT_FOUND);
            }

            employee.BirthDate = date;

            context.SaveChanges();
        }

        public List<EmployeesOlderThanDto> ListEmployeesOlderThan(int age)
        {
            var olderThanDtos = this.context.Employees.Where(e => DateTime.Now.Year - e.BirthDate.Value.Year > age)
                                            .ProjectTo<EmployeesOlderThanDto>(this.mapper.ConfigurationProvider)
                                            .OrderByDescending(e => e.Salary)
                                            .ToList();

            return olderThanDtos;
        }
    }
}
