using System;
using System.Collections.Generic;

namespace Shared;

public class Genre
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}