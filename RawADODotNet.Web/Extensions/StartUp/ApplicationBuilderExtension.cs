namespace RawADODotNet.Web.Extensions.StartUp
{
    /// <summary>
    /// Author : Mayank Morya
    /// Purpose: Use to manage all middle ware pipelines, Custom and In-built
    /// *ToDo: There is no need to perform any further action for current scenario
    /// </summary>
    public static class ApplicationBuilderExtension
    {
        public static WebApplication AddMiddlewarePipelines(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();

            return app;
        }
    }
}

