using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Errors;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi =true)]
    /*
    [ApiExplorerSettings(IgnoreApi =true)] 是一个特性（attribute），
    可以应用于控制器的方法上。它指示 Swagger 或其他 API 文档生成器忽略这个方法，
    不将其包括在生成的文档中。这个特性通常用于隐藏一些不想公开的 API 方法，
    例如内部测试方法或用于管理的方法。如果一个方法包含了这个特性，
    Swagger 将不会在生成的文档中包括该方法的相关信息。
    */
    public class ErrorController :BaseApiController
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}