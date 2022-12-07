using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.Json;
using Microsoft.OData.ModelBuilder;
using Shared;

var builder = WebApplication.CreateBuilder(args);
var jsonWriterFactory = new DefaultJsonWriterFactory(ODataStringEscapeOption.EscapeOnlyControls);

builder.Services.AddSingleton<IJsonWriterFactory>(jsonWriterFactory);
builder.Services.AddSingleton<IJsonWriterFactoryAsync>(jsonWriterFactory);
builder.Services
    .AddControllers()
    .AddOData(opt =>
    {
        static IEdmModel GetEdmModel<T>() where T: class
        {
            var edmBuilder = new ODataConventionModelBuilder();
            edmBuilder.EnableLowerCamelCase();
            edmBuilder.EntitySet<T>("edm");
            return edmBuilder.GetEdmModel();
        }

        var setJsonFactory = (IServiceCollection services) =>
        {
            services.AddSingleton<IJsonWriterFactory>(jsonWriterFactory);
            services.AddSingleton<IJsonWriterFactoryAsync>(jsonWriterFactory);
        };

        opt.AddRouteComponents("/api/authors", GetEdmModel<Author>(), setJsonFactory);
        opt.AddRouteComponents("/api/books", GetEdmModel<Book>(), setJsonFactory);
        opt.AddRouteComponents("/api/genres", GetEdmModel<Genre>(), setJsonFactory);
        opt.AddRouteComponents("/api/locations", GetEdmModel<Location>(), setJsonFactory);

        opt
            .Select()
            .OrderBy()
            .Expand()
            .Filter()
            .SetMaxTop(1000);
    });
builder.Services.AddDbContext<LibraryDbContext>();

var app = builder.Build();

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
    app.UseODataRouteDebug();

await using var scope = app.Services.CreateAsyncScope();
var db = scope.ServiceProvider.GetService<LibraryDbContext>();
await db!.Database.EnsureCreatedAsync();

#if false
await SeedingHelper.SeedDataAsync(app.Services);
#endif

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

await app.RunAsync("https://*:9000");