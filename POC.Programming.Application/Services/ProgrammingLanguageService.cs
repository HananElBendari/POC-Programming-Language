using AutoMapper;
using POC.Programming.Application.Interfaces;
using POC.Programming.Contract.Dtos;
using POC.Programming.Domain.Entities;
using POC.Programming.Infrastructure.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Programming.Application.Services
{
    public class ProgrammingLanguageService : IProgrammingLanguageService
    {
        private readonly IRepository<ProgrammingLanguage> programmingLanguageRepo;
        private readonly IMapper mapper;
        public ProgrammingLanguageService(IRepository<ProgrammingLanguage> _programmingLanguageRepo, IMapper _mapper)
        {
            programmingLanguageRepo = _programmingLanguageRepo;
            mapper = _mapper;
        }

        public async Task<List<ProgrammingLanguageDto>> GetProgrammingLanguageByCategoryAsync(int categoryId)
        {
            var programmingLanguageList = await programmingLanguageRepo.GetAllAsync(a => a.ProgrammingCategoryId == categoryId);
            return mapper.Map<List<ProgrammingLanguageDto>>(programmingLanguageList.ToList());
        }

        public void AddProgrammingLanguage(ProgrammingLanguageDto entity)
        {
            programmingLanguageRepo.Add(mapper.Map<ProgrammingLanguage>(entity));
        }
        public void UpdateProgrammingLanguage(ProgrammingLanguageDto entity)
        {
            programmingLanguageRepo.Update(mapper.Map<ProgrammingLanguage>(entity));
        }

        public ProgrammingLanguageDto GetProgrammingLanguageById(int id)
        {
            return mapper.Map<ProgrammingLanguageDto>(programmingLanguageRepo.Get(id));
        }

        public async Task<int> GetNumberOfHitsByProgrammingLanguageIdAsync(int programmingLanguageId)
        {
            var progLanguage = await programmingLanguageRepo.GetAsync(programmingLanguageId);
            return progLanguage.NumberOfHits;
        }

        public async Task<List<ProgrammingLanguageDto>> GetAllAsync()
        {
            var programmingLanguageList = await programmingLanguageRepo.GetAllIncludingAsync(e => e.ProgrammingCategory);
            return mapper.Map<List<ProgrammingLanguageDto>>(programmingLanguageList.ToList());
        }
    }
}
