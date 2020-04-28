using AutoMapper;
using POC.Programming.Application.Interfaces;
using POC.Programming.Contract.Dtos;
using POC.Programming.Domain.Entities;
using POC.Programming.Infrastructure.Repository;
using System.Linq;
using System.Threading.Tasks;

namespace POC.Programming.Application.Services
{
    public class ProgrammingLanguageDetailsService : IProgrammingLanguageDetailsService
    {
        private readonly IRepository<ProgrammingLanguageDetails> programmingLanguageDetailsRepo;
        private readonly IMapper mapper;
        public ProgrammingLanguageDetailsService(IRepository<ProgrammingLanguageDetails> _programmingLanguageDetailsRepo, IMapper _mapper)
        {
            programmingLanguageDetailsRepo = _programmingLanguageDetailsRepo;
            mapper = _mapper;
        }
        public async Task<ProgrammingLanguageDetailsDto> GetProgrammingLanguageDetailsByProgrammingLanguage(int programmingLanguageId)
        {
            var ProgrammingLanguageDetails = await programmingLanguageDetailsRepo.GetAllAsync(a => a.ProgrammingLanguageId == programmingLanguageId);
            return mapper.Map<ProgrammingLanguageDetailsDto>(ProgrammingLanguageDetails.FirstOrDefault());
        }

        public async Task<ProgrammingLanguageDetailsDto> GetProgrammingLanguageDetailsByUserIp(string userIp)
        {
            var ProgrammingLanguageDetails = await programmingLanguageDetailsRepo.GetAllAsync(a => a.UserIp == userIp);
            return mapper.Map<ProgrammingLanguageDetailsDto>(ProgrammingLanguageDetails.FirstOrDefault());
        }
        public void AddProgrammingLanguageDetails(ProgrammingLanguageDetailsDto entity)
        {
            programmingLanguageDetailsRepo.Add(mapper.Map<ProgrammingLanguageDetails>(entity));
        }

        public void UpdateProgrammingLanguageDetails(ProgrammingLanguageDetailsDto entity)
        {
            programmingLanguageDetailsRepo.Update(mapper.Map<ProgrammingLanguageDetails>(entity));
        }

        public ProgrammingLanguageDetailsDto GetProgrammingLanguageDetails(int id)
        {
            return mapper.Map<ProgrammingLanguageDetailsDto>(programmingLanguageDetailsRepo.Get(id));
        }
    }
}
