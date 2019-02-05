using AutoMapper;
using MappingObjectsExercise.Data.Models;
using MappingObjectsExercise.Dtos;

namespace MappingObjectsExercise
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<EmployeePersonalInfoDto, Employee>();
            CreateMap<Employee, EmployeePersonalInfoDto>();
            CreateMap<Employee, ManagerDto>();     
            CreateMap<ManagerDto, Employee>();
            CreateMap<Employee, EmployeesOlderThanDto>()
                .ForMember(dest => dest.ManagerName,
                src => src.MapFrom(e => e.Manager.FirstName + " " + e.Manager.LastName));
            CreateMap<EmployeesOlderThanDto, Employee>();
        }
    }
}
