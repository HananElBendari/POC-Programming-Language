using AutoMapper;
using Moq;
using POC.Programming.Application.Profiles;
using POC.Programming.Contract.Dtos;
using POC.Programming.Domain.Entities;
using POC.Programming.Infrastructure.Repository;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace POC.Programming.Application.Services.Tests
{
    public class ProgrammingLanguageDetailsServiceTests
    {
        private readonly ProgrammingLanguageDetailsService manager;
        private readonly Mock<IRepository<ProgrammingLanguageDetails>> moqIRepository;
        private readonly IMapper mapper;
        private readonly MapperConfiguration configuration;
        private readonly List<ProgrammingLanguageDetails> programmingLanguageDetails = new List<ProgrammingLanguageDetails>()
        {
            new ProgrammingLanguageDetails() {
            Id = 1,
            ProgrammingLanguageId = 1
            },
            new ProgrammingLanguageDetails() {
            Id = 2,
            ProgrammingLanguageId = 2
            }
        };

        public ProgrammingLanguageDetailsServiceTests()
        {
            moqIRepository = new Mock<IRepository<ProgrammingLanguageDetails>>();
            moqIRepository.Setup(a => a.SingleOrDefaultAsync(It.IsAny<Expression<Func<ProgrammingLanguageDetails, bool>>>()))
                .ReturnsAsync(
                (Expression<Func<ProgrammingLanguageDetails, bool>> expression) =>
                {
                    return programmingLanguageDetails.AsQueryable().SingleOrDefault(expression);
                }

                );
            configuration = new MapperConfiguration(cfg => cfg.AddProfile<ProgrammingProfile>());
            mapper = new Mapper(configuration);
            manager = new ProgrammingLanguageDetailsService(moqIRepository.Object, mapper);
        }

        [Theory]
        [InlineData(2, 2)]
        public void GetAllAsync_ByDefault_ReturnAllProgrammingCategories(int id, int expectedProgramingLangId)
        {
            //Act
            var result = manager.GetProgrammingLanguageDetailsByProgrammingLanguage(id);

            //Assert
            result.ShouldSatisfyAllConditions
             (
                () => result.ShouldBeOfType<Task<ProgrammingLanguageDetailsDto>>(),
                () => result.Result.Id.ShouldBe(id),
                () => result.Result.ProgrammingLanguageId.ShouldBe(expectedProgramingLangId)
             );
        }
    }
}


