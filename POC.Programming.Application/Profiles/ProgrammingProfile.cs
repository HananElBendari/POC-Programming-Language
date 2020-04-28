using AutoMapper;
using POC.Programming.Contract.Dtos;
using POC.Programming.Domain.Entities;

namespace POC.Programming.Application.Profiles
{
    public class ProgrammingProfile : Profile
    {
        public ProgrammingProfile()
        {
            CreateMap<ProgrammingCategory, ProgrammingCategoryDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, ProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguageDetails, ProgrammingLanguageDetailsDto>().ReverseMap();
        }

    }
}
