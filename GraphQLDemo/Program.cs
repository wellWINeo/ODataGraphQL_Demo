using GraphQLDemo;
using GraphQLDemo.Conventions;
using Shared;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LibraryDbContext>();

// GraphQL
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddFiltering<CustomFilteringConvention>()
    .AddProjections()
    .AddSorting();

var app = builder.Build();

app.UseHttpsRedirection();

await using var scope = app.Services.CreateAsyncScope();
var db = scope.ServiceProvider.GetService<LibraryDbContext>();
await db!.Database.EnsureCreatedAsync();

#if false
await SeedingHelper.SeedDataAsync(app.Services);
#endif

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapGraphQL();
});

app.Run();