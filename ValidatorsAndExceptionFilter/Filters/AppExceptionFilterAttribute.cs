using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace ValidatorsAndExceptionFilter.Filters
{
    public class AppExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<AppExceptionFilterAttribute> _logger;

        public AppExceptionFilterAttribute(ILogger<AppExceptionFilterAttribute> logger)
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, context.Exception.StackTrace);

            if (context.Exception is NotFoundException)
            {
                context.HttpContext.Response.StatusCode = 404;
            }
            else
            {
                context.HttpContext.Response.StatusCode = 500;
            }

            context.Result = new JsonResult(new Dictionary<string, object>
            {
                { "Error" , context.Exception.Message },
                { "StackTrace", context.Exception.StackTrace }
            });
        }
    }

    // Custom NotFoundException
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}




//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.Filters;
//using Microsoft.Extensions.Logging;
//using Serilog;
//using System.Collections.Generic;

//namespace ValidatorsAndExceptionFilter.Filters
//{
//    public class AppExceptionFilterAttribute : ExceptionFilterAttribute
//    {
//        private readonly ILogger<AppExceptionFilterAttribute> _logger;

//        public AppExceptionFilterAttribute(ILogger<AppExceptionFilterAttribute> logger)
//        {
//            _logger = logger;
//        }

//        public override void OnException(ExceptionContext context)
//        {
//            _logger.LogError(context.Exception, context.Exception.StackTrace);

//            context.HttpContext.Response.StatusCode = 500;

//            context.Result = new JsonResult(new Dictionary<string, object>
//            {
//                { "Error" , context.Exception.Message },
//                { "StackTrace", context.Exception.StackTrace }
//            });
//        }
//    }
//}
