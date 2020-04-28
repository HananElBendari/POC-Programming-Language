using POC.Programming.Contract.Dtos;
using System.Threading.Tasks;

namespace POC.Programming.Application.Interfaces
{
    public interface IProgrammingLanguageDetailsService
    {
        Task<ProgrammingLanguageDetailsDto> GetProgrammingLanguageDetailsByProgrammingLanguage(int programmingLanguageId);
        Task<ProgrammingLanguageDetailsDto> GetProgrammingLanguageDetailsByUserIp(string userIp);
        ProgrammingLanguageDetailsDto GetProgrammingLanguageDetails(int id);
        void AddProgrammingLanguageDetails(ProgrammingLanguageDetailsDto entity);
        void UpdateProgrammingLanguageDetails(ProgrammingLanguageDetailsDto entity);
    }
}
