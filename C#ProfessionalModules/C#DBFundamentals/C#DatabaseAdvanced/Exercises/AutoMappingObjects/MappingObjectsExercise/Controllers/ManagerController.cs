using AutoMapper;
using AutoMapper.QueryableExtensions;
using MappingObjectsExercise.Contracts.Controllers;
using MappingObjectsExercise.Data;
using MappingObjectsExercise.Dtos;
using System;
using System.Linq;

namespace MappingObjectsExercise.Controllers
{
    public class ManagerController : IManagerController
    {
        private const string EMPLOYEE_NOT_FOUND = "Employee not found!";
        private const string MANAGER_NOT_FOUND = "Manager not found!";

        private IMapper mapper;
        private MappingObjectsExerciseContext context;

        public ManagerController(IMapper mapper, MappingObjectsExerciseContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public ManagerDto GetManagerInfo(int managerId)
        {
            var employee = this.context.Employees.Find(managerId);

            if(employee == null)
            {
                throw new ArgumentException(EMPLOYEE_NOT_FOUND);
            }

            var managerDto = this.mapper.Map<ManagerDto>(employee);

            EmployeeDto[] employees = context.Employees.Where(e => e.ManagerId == employee.Id)
                             .ProjectTo<EmployeeDto>(this.mapper.ConfigurationProvider)
                             .ToArray();

            foreach (var emp in employees)
            {
                managerDto.EmployeeDtos.Add(emp);
            }

            return managerDto;
        }

        public void SetManager(int employeeId, int managerId)
        {
            var employee = this.context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException(EMPLOYEE_NOT_FOUND);
            }

            var manager = this.context.Employees.Find(managerId);

            if (manager == null)
            {
                throw new ArgumentException(MANAGER_NOT_FOUND);
            }

            employee.Manager = manager;

            context.SaveChanges();
        }
    }
}
