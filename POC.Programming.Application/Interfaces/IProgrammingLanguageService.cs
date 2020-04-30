using POC.Programming.Contract.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.Programming.Application.Interfaces
{
    public interface IProgrammingLanguageService
    {
        Task<List<ProgrammingLanguageDto>> GetProgrammingLanguageByCategoryAsync(int categoryId);
        void UpdateProgrammingLanguage(ProgrammingLanguageDto entity);
        ProgrammingLanguageDto GetProgrammingLanguageById(int id);
    }
}
