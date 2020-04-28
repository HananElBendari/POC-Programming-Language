using POC.Programming.Contract.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.Programming.Application.Interfaces
{
    public interface IProgrammingCategoryService
    {
        Task<int> NumberOfAvaliableCategories();
        Task<List<ProgrammingCategoryDto>> GetAllAsync();
    }
}
