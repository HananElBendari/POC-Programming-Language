using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using POC.Programming.Contract.Request;

namespace POC.Programming.Web.Controllers
{
    [ApiController]
    [Route("api/LogErrors")]
    public class LogErrorsController : ControllerBase
    {
        private readonly ILogger<LogErrorsController> logger;

        /// <summary>
        /// LogErrors
        /// </summary>
        public LogErrorsController(ILogger<LogErrorsController> _logger)
        {
            logger = _logger;
        }

        /// <summary>
        /// Log error
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public ActionResult<bool> Log(ErrorRequest ex)
        {
            logger.LogError(default(EventId), ex.ToString(), ex.Message);
            return Ok(true);
        }

    }
}
