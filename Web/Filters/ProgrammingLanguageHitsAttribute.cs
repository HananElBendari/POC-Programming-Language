using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using POC.Programming.Application.Interfaces;
using System;

namespace POC.Programming.Web.Filters
{
    public class ProgrammingLanguageHitsAttribute : IActionFilter
    {
        private readonly IProgrammingLanguageService programmingLanguageService;
        public ProgrammingLanguageHitsAttribute(IProgrammingLanguageService _programmingLanguageService)
        {
            programmingLanguageService = _programmingLanguageService;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            int id;
            if (context.ActionArguments.ContainsKey("programmingLanguageId"))
            {
                id = int.Parse(context.ActionArguments["programmingLanguageId"].ToString());
            }
            else
            {
                context.Result = new BadRequestObjectResult("Bad parameter");
                return;
            }

            string userIp = context.HttpContext.Request.Cookies[$"UserIp{id}"];

            if (userIp == null)
            {
                userIp = Guid.NewGuid().ToString();

                var entity = programmingLanguageService.GetProgrammingLanguageById(id);
                if (entity != null)
                {
                    entity.NumberOfHits += 1;
                    programmingLanguageService.UpdateProgrammingLanguage(entity);
                }
                context.HttpContext.Response.Cookies.Append($"UserIp{id}", userIp, new CookieOptions()
                {
                    Path = "/",
                    HttpOnly = true,
                    Secure = false,
                });
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

    }
}
