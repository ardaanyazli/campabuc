namespace CamPabuc.Api.Middleware;

public class RequestCancellationMiddleware(RequestDelegate next, ILogger<RequestCancellationMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (OperationCanceledException) when (context.RequestAborted.IsCancellationRequested)
        {
            logger.LogWarning("Request was cancelled by the client. Path: {Path}", context.Request.Path);

            if (!context.Response.HasStarted)
            {
                context.Response.Clear();
                context.Response.StatusCode = 499; // Client Closed Request (unofficial)
                await context.Response.WriteAsync("Request cancelled by client");
            }
        }
    }
}

