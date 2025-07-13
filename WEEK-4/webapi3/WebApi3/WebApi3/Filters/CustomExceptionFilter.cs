using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApi3.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            // Capture exception details
            var exception = context.Exception;
            var exceptionMessage = $"Exception occurred at {DateTime.Now}: {exception.Message}";
            var stackTrace = exception.StackTrace;

            // Write to file in system
            var logPath = Path.Combine(Directory.GetCurrentDirectory(), "error_log.txt");
            var logEntry = $"{DateTime.Now}: {exceptionMessage}\nStack Trace: {stackTrace}\n\n";

            try
            {
                File.AppendAllText(logPath, logEntry);
            }
            catch
            {
                // If file writing fails, continue with response
            }

            // Set the Result property of exception context
            context.Result = new ObjectResult(new
            {
                error = "Internal Server Error",
                message = exception.Message,
                timestamp = DateTime.Now
            })
            {
                StatusCode = 500
            };

            // Mark exception as handled
            context.ExceptionHandled = true;
        }
    }
}
