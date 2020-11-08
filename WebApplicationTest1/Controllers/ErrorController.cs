using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApplicationTest1.Controllers
{

    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly ILogger<ErrorController> _logger;
        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [Route("/error-local-development")]
        public IActionResult ErrorLocalDevelopment([FromServices] IWebHostEnvironment webHostEnvironment)
        {
            //if (webHostEnvironment.EnvironmentName != "Development")
            //{
            //    throw new InvalidOperationException(
            //        "This shouldn't be invoked in non-development environments.");
            //}

            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();

            //ErrorResonse errorReponse = new ErrorResonse { ErrorId = 50010, ErrorMessgae = "Error in Server " ,StackTrace= context.Error.StackTrace };
            //_logger.Log(LogLevel.Error, JsonSerializer.Serialize(errorReponse));
            //return StatusCode(500, errorReponse);

            //_logger.Log(LogLevel.Error, "StatusCode - 50010 , ErrorMessage - " + context.Error.Message + " , StackTrace - " + context.Error.StackTrace, null);
            //_logger.Log(LogLevel.Error, "StatusCode - 50010 , ErrorMessage - " + context.Error.Message , null);
            //

            return StatusCode(500, new ErrorResonse { ErrorId = 50010, ErrorMessgae = "Error in Server" });
            // return StatusCode(500);
            //return Problem(
            //detail: context.Error.StackTrace,
            //title: context.Error.Message);

            //return Problem();

        }

        [Route("/error")]
        public IActionResult Error() => Problem();


        public class ErrorResonse
        {
            public int ErrorId { get; set; }
            public string ErrorMessgae { get; set; }

            public string StackTrace { get; set; }

        }
        public class Employee
        {
            public int EmpID { get; set; }
            public string EmpName { get; set; }
        }
    }
}
