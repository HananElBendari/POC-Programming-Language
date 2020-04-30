using POC.Programming.Contract.Dtos;
using System.Threading.Tasks;

namespace POC.Programming.Application.Interfaces
{
    public interface IProgrammingLanguageDetailsService
    {
        Task<ProgrammingLanguageDetailsDto> GetProgrammingLanguageDetailsByProgrammingLanguage(int programmingLanguageId);
    }
}
