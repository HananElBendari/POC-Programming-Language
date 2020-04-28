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
    [Route("api/ProgrammingCategory")]
    public class ProgrammingCategoryController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IProgrammingCategoryService programmingCategoryService;

        /// <summary>
        /// ProgrammingCategory
        /// </summary>
        public ProgrammingCategoryController(ILogger<ProgrammingCategoryController> _logger, IProgrammingCategoryService _programmingCategoryService)
        {
            logger = _logger;
            programmingCategoryService = _programmingCategoryService;
        }

        /// <summary>
        /// Get all programming categories async
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(typeof(List<ProgrammingCategoryDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<List<ProgrammingCategoryDto>>> GetAllAsync()
        {
            try
            {
                var result = await programmingCategoryService.GetAllAsync();
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
