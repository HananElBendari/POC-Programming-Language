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
    public class ProgrammingLanguageServiceTests
    {
        private readonly ProgrammingLanguageService manager;
        private readonly Mock<IRepository<ProgrammingLanguage>> moqIRepository;
        private readonly IMapper mapper;
        private readonly MapperConfiguration configuration;
        private readonly List<ProgrammingLanguage> programmingLanguage = new List<ProgrammingLanguage>()
        {
           new ProgrammingLanguage()
           {
                Id = 1,
                ProgrammingLanguageName = "Language 1",
                ProgrammingCategoryId = 1
           },
          new ProgrammingLanguage()
           {
                Id = 2,
                ProgrammingLanguageName = "Language 2",
                ProgrammingCategoryId = 1
           }
        };

        public ProgrammingLanguageServiceTests()
        {
            moqIRepository = new Mock<IRepository<ProgrammingLanguage>>();
            moqIRepository.Setup(a => a.GetAllAsync(It.IsAny<Expression<Func<ProgrammingLanguage, bool>>>()))
            .ReturnsAsync(
                (Expression<Func<ProgrammingLanguage, bool>> expression) => { return programmingLanguage.AsQueryable().Where(expression); });
            moqIRepository.Setup(a => a.Update(It.IsAny<ProgrammingLanguage>()));
            moqIRepository.Setup(a => a.Get(It.IsAny<int>())).Returns(
                (int id) =>
                {
                    return programmingLanguage.SingleOrDefault(a => a.Id == id);
                });
            configuration = new MapperConfiguration(cfg => cfg.AddProfile<ProgrammingProfile>());
            mapper = new Mapper(configuration);
            manager = new ProgrammingLanguageService(moqIRepository.Object, mapper);
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(0, 0)]
        public void GetProgrammingLanguageByCategoryAsync_ByDefault_ReturnAllProgrammingLanguage(int id, int expectedResult)
        {
            //Act
            var result = manager.GetProgrammingLanguageByCategoryAsync(id);

            //Assert
            result.ShouldSatisfyAllConditions
             (
                () => result.ShouldBeOfType<Task<List<ProgrammingLanguageDto>>>(),
                () => result.Result.Count.ShouldBe(expectedResult)

             );
        }


        [Fact]
        public void UpdateProgrammingLanguage_ByDefault_UpdateEntity()
        {
            //Arrange
            ProgrammingLanguageDto entity = new ProgrammingLanguageDto()
            {
                Id = 1,
                ProgrammingCategoryId = 2,
            };

            //Act
            manager.UpdateProgrammingLanguage(entity);

            //Assert
            moqIRepository.Verify(a => a.Update(It.IsAny<ProgrammingLanguage>()));
        }

        [Theory]
        [InlineData(1, 1)]
        public void GetProgrammingLanguageById_ByDefault_ReturnAllProgrammingLanguage(int id, int expectedResult)
        {
            //Act
            var result = manager.GetProgrammingLanguageById(id);

            //Assert
            result.ShouldSatisfyAllConditions
             (
                () => result.ShouldBeOfType<ProgrammingLanguageDto>(),
                () => result.Id.ShouldBe(expectedResult)

             );
        }

    }
}


