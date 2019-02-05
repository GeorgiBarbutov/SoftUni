namespace PetClinic.App
{
    using AutoMapper;
    using PetClinic.App.Dtos.ImportDtos;
    using PetClinic.App.Dtos.ExportDtos;
    using PetClinic.Models;

    public class PetClinicProfile : Profile
    {
        // Configure your AutoMapper here if you wish to use it. If not, DO NOT DELETE THIS CLASS
        public PetClinicProfile()
        {
            CreateMap<AnimalAidDto, AnimalAid>().ReverseMap();
            CreateMap<Dtos.ImportDtos.AnimalDto, Animal>().ReverseMap();
            CreateMap<PassportDto, Passport>().ReverseMap();
            CreateMap<VetDto, Vet>().ReverseMap();
            CreateMap<Animal, Dtos.ExportDtos.AnimalDto>()
                .ForMember(dest => dest.Age,
                           opt => opt.MapFrom(src => src.Age))
                .ForMember(dest => dest.SerialNumber,
                           opt => opt.MapFrom(src => src.PassportSerialNumber))
                .ForMember(dest => dest.AnimalName,
                           opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.OwnerName,
                           opt => opt.MapFrom(src => src.Passport.OwnerName))
                .ForMember(dest => dest.RegisteredOn,
                           opt => opt.MapFrom(src => src.Passport.RegistrationDate));

            CreateMap<AnimalAid, ExportAnimalAids>().ReverseMap();

            CreateMap<Procedure, ExportProcedureDto>()
                .ForMember(dest => dest.Passport,
                           opt => opt.MapFrom(src => src.Animal.PassportSerialNumber))
                .ForMember(dest => dest.OwnerNumber,
                           opt => opt.MapFrom(src => src.Animal.Passport.OwnerPhoneNumber))
                .ForMember(dest => dest.AnimalAids,
                           opt => opt.MapFrom(src => src.ProcedureAnimalAids));
        }
    }
}
