using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using POC.Programming.Application.Interfaces;
using POC.Programming.Contract.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POC.Programming.Web.Controllers
{
    [ApiController]
    [Route("api/ProgrammingLanguage")]
    public class ProgrammingLanguageController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IProgrammingLanguageService programmingLanguageService;

        /// <summary>
        /// ProgrammingLanguage
        /// </summary>
        public ProgrammingLanguageController(ILogger<ProgrammingCategoryController> _logger, IProgrammingLanguageService _programmingLanguageService)
        {
            logger = _logger;
            programmingLanguageService = _programmingLanguageService;
        }

        /// <summary>
        /// Get programming language by category async
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{categoryId}")]
        [ProducesResponseType(typeof(List<ProgrammingLanguageDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ProgrammingLanguageDto>>> GetProgrammingLanguageByCategoryAsync(int categoryId)
        {
            try
            {
                var result = await programmingLanguageService.GetProgrammingLanguageByCategoryAsync(categoryId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
