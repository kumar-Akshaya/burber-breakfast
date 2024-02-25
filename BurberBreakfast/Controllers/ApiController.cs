using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BurberBreakfast.Controllers;

[ApiController]
[Route("controller")]
public class ApiController : ControllerBase 
{
    protected IActionResult Problem(List<Error>, errors)
    {
        if (errors.All(e => e.Type == ErrorType.Validation))
        {
            var modelStateDictionary = new ModelStateDictionary();
            
        foreach (var error in errors)
        {
            modelStateDictionary.AddModelError(error.code, error.description);
        }
        
        return ValidationProblem(modelStateDictionary);

        }

        if (errors.Any(e => e.Type == ErrorType.UnExpected))
        {
            return Problem();
        }

        var firstError = errors[0];

        var statusCode = firstError.Type switch 
        {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            _ => StatusCodes => Status500InternalServerError
        };

        return Problem(StatusCode: statusCode, title: firstError.Description);
    }
}