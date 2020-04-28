using AutoMapper;
using POC.Programming.Application.Interfaces;
using POC.Programming.Contract.Dtos;
using POC.Programming.Domain.Entities;
using POC.Programming.Infrastructure.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.Programming.Application.Services
{
    public class ProgrammingCategoryService : IProgrammingCategoryService
    {
        private readonly IRepository<ProgrammingCategory> programmingCategoryRepo;
        private readonly IMapper mapper;
        public ProgrammingCategoryService(IRepository<ProgrammingCategory> _programmingCategoryRepo, IMapper _mapper)
        {
            programmingCategoryRepo = _programmingCategoryRepo;
            mapper = _mapper;
        }
        public async Task<int> NumberOfAvaliableCategories()
        {
            return await programmingCategoryRepo.Count();
        }

        public async Task<List<ProgrammingCategoryDto>> GetAllAsync()
        {
            var programmingCategoryList = await programmingCategoryRepo.GetAllAsync();
            return mapper.Map<List<ProgrammingCategoryDto>>(programmingCategoryList);
        }
    }
}
