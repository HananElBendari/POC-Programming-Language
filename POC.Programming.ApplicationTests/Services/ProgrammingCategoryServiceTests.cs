using AutoMapper;
using Moq;
using POC.Programming.Application.Profiles;
using POC.Programming.Contract.Dtos;
using POC.Programming.Domain.Entities;
using POC.Programming.Infrastructure.Repository;
using Shouldly;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace POC.Programming.Application.Services.Tests
{
    public class ProgrammingCategoryServiceTests
    {
        private readonly ProgrammingCategoryService manager;
        private readonly Mock<IRepository<ProgrammingCategory>> moqIRepository;
        private readonly IMapper mapper;
        private readonly MapperConfiguration configuration;

        private readonly List<ProgrammingCategory> programmingCategories = new List<ProgrammingCategory>()
        {
            new ProgrammingCategory()
            {
                Id = 1,
                ProgrammingCategoryName = "Category 1"
            }
        };

        public ProgrammingCategoryServiceTests()
        {
            moqIRepository = new Mock<IRepository<ProgrammingCategory>>();
            moqIRepository.Setup(a => a.Count()).ReturnsAsync(1);
            moqIRepository.Setup(a => a.GetAllAsync()).ReturnsAsync(programmingCategories);
            configuration = new MapperConfiguration(cfg => cfg.AddProfile<ProgrammingProfile>());
            mapper = new Mapper(configuration);
            manager = new ProgrammingCategoryService(moqIRepository.Object, mapper);
        }

        [Theory]
        [InlineData(1)]
        public void NumberOfAvaliableCategoriesAsync_ByDefault_ReturnNumberOfAvaliableCategories(int expectedResult)
        {
            //Act
            var result = manager.GetNumberOfAvaliableCategoriesAsync();

            //Assert
            result.ShouldSatisfyAllConditions
             (
                () => result.Result.ShouldBeOfType<int>(),
                () => result.Result.ShouldBe(expectedResult)
             );
        }

        [Theory]
        [InlineData("Category 1")]
        public void GetAllAsync_ByDefault_ReturnAllProgrammingCategories(string expectedResult)
        {
            //Act
            var result = manager.GetAllAsync();

            //Assert
            result.ShouldSatisfyAllConditions
             (
                () => result.ShouldBeOfType<Task<List<ProgrammingCategoryDto>>>(),
                () => result.Result.FirstOrDefault().ProgrammingCategoryName.ShouldBe(expectedResult)

             );
        }
    }
}


