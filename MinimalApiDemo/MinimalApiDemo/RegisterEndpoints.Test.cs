using Microsoft.AspNetCore.Mvc;

namespace MinimalApiDemo;

public static partial class RegisterEndpoints
{
    public static void AddTestModule(this WebApplication? app)
    {
        app.MapGroup("demo/{demoId:int}/test")
            .MapTestApi()
            .WithTags("Test")
        .WithOpenApi();
    }

    private static RouteGroupBuilder MapTestApi(this RouteGroupBuilder group)
    {
        group.MapGetTestEndpoints();
        return group;
    }

    private static void MapGetTestEndpoints(this RouteGroupBuilder group)
    {
        group.MapGet("/",
                async (
                        [FromRoute] int demoId,
                        [FromQuery] string searchQuery,
                        [FromServices] TestApi module) =>
                    await module.GetTestList(demoId))
            .WithName("GetTestList")
            .WithSummary("Get test list")
            .WithDescription("This endpoint returns test list based on search query")
            .Produces<IEnumerable<int>>(StatusCodes.Status200OK)
            .ProducesStandardGetResponses();

        group.MapGet("/{id:int}",
                async (
                        [FromRoute] int demoId,
                        [FromRoute] int id,
                        [FromServices] TestApi module) =>
                    await module.GetTestById(demoId, id))
            .WithName("GetTest")
            .Produces<int>(StatusCodes.Status200OK)
            .ProducesStandardGetResponses();
    }
}