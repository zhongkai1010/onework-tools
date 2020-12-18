using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace OneWork.Server.Base
{
    /// <summary>
    /// </summary>
    public class ResponseResultFilterAttribute : Attribute, IActionFilter
    {
        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuted(ActionExecutedContext context)
        {
            ResponseResult responseResult = new ResponseResult();
            try
            {
                if (context.Result is ObjectResult objectResult)
                {
                    responseResult.Data = objectResult.Value;
                }
                responseResult.Success = true;
            }
            catch (Exception e)
            {
                responseResult.Data = null;
                responseResult.Success = false;
                responseResult.ErrorMessage = e.Message;
            }
            JsonResult jsonResult = new JsonResult(responseResult);
            context.Result = jsonResult;
        }

        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}