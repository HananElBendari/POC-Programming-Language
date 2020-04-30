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

        private int CheckParams(ActionExecutingContext context)
        {
            if (!context.ActionArguments.ContainsKey("programmingLanguageId"))
            {
                context.Result = new BadRequestObjectResult("Bad parameter");
                return 0;
            }

            return int.Parse(context.ActionArguments["programmingLanguageId"].ToString());
        }

        private void UpdateNumberOfHits(int id)
        {
            var entity = programmingLanguageService.GetProgrammingLanguageById(id);
            if (entity != null)
            {
                entity.NumberOfHits += 1;
                programmingLanguageService.UpdateProgrammingLanguage(entity);
            }
        }

        private void AddCookies(ActionExecutingContext context, int id)
        {
            string userIp = Guid.NewGuid().ToString();
            context.HttpContext.Response.Cookies.Append($"UserIp{id}", userIp, new CookieOptions()
            {
                Path = "/",
                HttpOnly = true,
                Secure = false,
            });
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {

            int id = CheckParams(context);
            if (id == 0) return;

            string userIp = context.HttpContext.Request.Cookies[$"UserIp{id}"];
            if (userIp == null)
            {
                UpdateNumberOfHits(id);
                AddCookies(context, id);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

    }
}
