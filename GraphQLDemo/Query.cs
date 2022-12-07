using Shared;
using Location = Shared.Location;

namespace GraphQLDemo;

public class Query
{
    [UseFiltering]
    public IQueryable<Author> GetAuthors([Service] LibraryDbContext context)
        => context.Set<Author>();
    
    [UseFiltering]
    public IQueryable<Book> GetBooks([Service] LibraryDbContext context)
        => context.Set<Book>();

    [UseFiltering]
    public IQueryable<Genre> GetGenres([Service] LibraryDbContext context)
        => context.Set<Genre>();

    [UseFiltering]
    public IQueryable<Location> GetLocations([Service] LibraryDbContext context)
        => context.Set<Location>();
}