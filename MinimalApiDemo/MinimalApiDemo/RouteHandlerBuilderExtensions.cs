namespace MinimalApiDemo;

public static class RouteHandlerBuilderExtensions
{
    public static RouteHandlerBuilder ProducesStandardGetResponses(this RouteHandlerBuilder handler)
    {
        handler.Produces(StatusCodes.Status404NotFound)
            .Produces(StatusCodes.Status401Unauthorized);
        return handler;
    }
    public static RouteHandlerBuilder ProducesStandardPostResponses(this RouteHandlerBuilder handler)
    {
        handler.Produces<int>(StatusCodes.Status201Created)
            .Produces(StatusCodes.Status400BadRequest)
            .Produces<ErrorResponse>(StatusCodes.Status422UnprocessableEntity);
        return handler;
    }

    public static RouteHandlerBuilder ProducesStandardDeleteResponses(this RouteHandlerBuilder handler)
    {
        handler.Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound);
        return handler;
    }

    public static RouteHandlerBuilder ProducesStandardPatchResponses(this RouteHandlerBuilder handler)
    {
        handler.Produces<int>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .Produces<ErrorResponse>(StatusCodes.Status409Conflict);
        return handler;
    }

    public static RouteHandlerBuilder ProducesStandardPutResponses(this RouteHandlerBuilder handler)
    {
        handler.Produces(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound)
            .Produces<ErrorResponse>(StatusCodes.Status409Conflict);
        return handler;
    }
}

public class ErrorResponse
{
    public string ErrorCode { get; set; }
    public string ErrorMessage { get; set; }
    public object? Data { get; set; }
}