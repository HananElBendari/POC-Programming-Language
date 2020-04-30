using AutoMapper;
using POC.Programming.Application.Profiles;
using POC.Programming.Contract.Dtos;
using POC.Programming.Domain.Entities;
using Xunit;
using Shouldly;

namespace POC.Programming.Application.Services.Profiles
{
    public class ProgrammingProfileAutoMapperTests
    {
        private readonly IMapper _mapper;
        private readonly MapperConfiguration configuration;

        public ProgrammingProfileAutoMapperTests()
        {
             configuration = new MapperConfiguration(cfg => cfg.AddProfile<ProgrammingProfile>());
            _mapper = new Mapper(configuration);
        }

        [Fact]
        public void ShouldMapPropertySitusAddressToPropertySitusAddressDto()
        {
            configuration.FindTypeMapFor<ProgrammingCategory, ProgrammingCategoryDto>().ShouldNotBeNull();
            configuration.FindTypeMapFor<ProgrammingLanguage, ProgrammingLanguageDto>().ShouldNotBeNull();
            configuration.FindTypeMapFor<ProgrammingLanguageDetails, ProgrammingLanguageDetailsDto>().ShouldNotBeNull();
        }
    }
}
