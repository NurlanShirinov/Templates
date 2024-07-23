using Common.Exceptions;
using Common.GlobalExceptionResponses;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace TemplateProject.Infrastructure.Middlewares;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (BadRequestException error)
        {
            var message = new ResponseModel(error.Message, ErrorType.BAD_REQUEST);
            await WriteError(context, HttpStatusCode.BadRequest, message);
        }
        //catch (ValidationException error)
        //{
        //    var message = new ResponseModel(error.Message, ErrorType.VALIDATION_ERROR);
        //    await WriteError(context, HttpStatusCode.BadRequest, message);
        //}
        //not found exception tut
        static async Task WriteError(HttpContext context, HttpStatusCode hhtpStatusCode, ResponseModel errorResponse)
        {
            var statusCode = (int)hhtpStatusCode;
            context.Response.Clear();
            context.Response.StatusCode = statusCode;
            context.Response.ContentType = "application/json; charset=utf-8";

            var options = new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var json = JsonSerializer.Serialize(errorResponse, options);
            await context.Response.WriteAsync(json);
        }
    }
}
