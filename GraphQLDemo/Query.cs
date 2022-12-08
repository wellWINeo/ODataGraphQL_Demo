using Shared;
using Location = Shared.Location;

namespace GraphQLDemo;

public class Query
{
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Author> GetAuthors([Service] LibraryDbContext context)
        => context.Set<Author>();
    
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Book> GetBooks([Service] LibraryDbContext context)
        => context.Set<Book>();

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Genre> GetGenres([Service] LibraryDbContext context)
        => context.Set<Genre>();

    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Location> GetLocations([Service] LibraryDbContext context)
        => context.Set<Location>();
}