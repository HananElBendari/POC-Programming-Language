using AutoMapper;
using POC.Programming.Application.Interfaces;
using POC.Programming.Contract.Dtos;
using POC.Programming.Domain.Entities;
using POC.Programming.Infrastructure.Repository;
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
            var ProgrammingLanguageDetails = await programmingLanguageDetailsRepo.SingleOrDefaultAsync(a => a.ProgrammingLanguageId == programmingLanguageId);
            return mapper.Map<ProgrammingLanguageDetailsDto>(ProgrammingLanguageDetails);
        }
    }
}
