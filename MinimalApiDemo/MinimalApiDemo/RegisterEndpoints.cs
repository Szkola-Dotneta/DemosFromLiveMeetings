namespace MinimalApiDemo;

public static partial class RegisterEndpoints
{
    public static void ConfigureDemoModule(this WebApplication? app)
    {
        app.AddTestModule();
    }
}