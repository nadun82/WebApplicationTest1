using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;

namespace WebApplicationTest1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        [Authorize]
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetEmployee(int id)
        {
            if (id > 0 && id <= 1000)
            {
                //return Ok(new Employee { EmpID = id, EmpName = "Nadun" });
                return StatusCode(200, new Employee { EmpID = id, EmpName = "Nadun" });
            }
            else if (id > 1000)
            {
                throw new Exception("Invalid ID");
            }
            //return NotFound();
            //return NotFound(new ErrorResonse { ErrorId=4001 ,ErrorMessgae="EmployeeID No Found"})
            ErrorResonse errorReponse = new ErrorResonse { ErrorId = 40410, ErrorMessgae = "EmployeeID No Found" };
            _logger.Log(LogLevel.Error, JsonSerializer.Serialize(errorReponse));
            return StatusCode(404, errorReponse);
        }


        [HttpPost]
        public IActionResult SaveEmployee(Employee emp)
        {
            return Ok(emp.EmpID);
        }
    }

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
