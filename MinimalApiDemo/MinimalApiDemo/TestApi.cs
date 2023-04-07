namespace MinimalApiDemo;

public class TestApi
{
    public async Task<IResult> GetTestList(int demoId)
    {
        var response = new List<int>() { 1, 2, 3, 4, 5 };
        return Results.Ok(response);
    }

    public async Task<IResult> GetTestById(int demoId, int id)
    {
        return Results.Ok(id);
    }
}