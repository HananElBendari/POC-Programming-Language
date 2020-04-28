using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using POC.Programming.Application.Interfaces;
using POC.Programming.Contract.Dtos;
using POC.Programming.Web.Filters;
using System;
using System.Threading.Tasks;

namespace POC.Programming.Web.Controllers
{
    [ApiController]
    [Route("api/ProgrammingLanguageDetails")]
    public class ProgrammingLanguageDetailsController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IProgrammingLanguageDetailsService programmingLanguageDetailsService;

        /// <summary>
        /// ProgrammingLanguageDetails
        /// </summary>
        public ProgrammingLanguageDetailsController(ILogger<ProgrammingCategoryController> _logger, IProgrammingLanguageDetailsService _programmingLanguageDetailsService)
        {
            logger = _logger;
            programmingLanguageDetailsService = _programmingLanguageDetailsService;
        }

        /// <summary>
        /// Get programming language details async
        /// </summary>
        /// <param name="programmingLanguageId"></param>
        /// <returns></returns>
        [ServiceFilter(typeof(ProgrammingLanguageHitsAttribute))]
        [HttpGet]
        [Route("[action]/{programmingLanguageId}")]
        [ProducesResponseType(typeof(ProgrammingLanguageDetailsDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ProgrammingLanguageDetailsDto>> GetProgrammingLanguageDetailsAsync(int programmingLanguageId)
        {
            try
            {
                return Ok(await programmingLanguageDetailsService.GetProgrammingLanguageDetailsByProgrammingLanguage(programmingLanguageId));
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
