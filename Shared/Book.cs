using System;
using System.Collections.Generic;

namespace Shared;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public int PublishedYear { get; set; }
    public virtual Author Author { get; set; }
    public Guid AuthorId { get; set; }
    public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();
}