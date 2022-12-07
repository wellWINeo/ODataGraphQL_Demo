using System;
using System.Collections.Generic;

namespace Shared;

public class Author
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = default!;
    public string MiddleName { get; set; } = default!;
    public string LastName { get; set; } = default!;
    public DateOnly BirthData { get; set; }
    public virtual Location BirthLocation { get; set; }
    public Guid BirthLocationId { get; set; }
    public virtual Location? LiveLocation { get; set; }
    public Guid LiveLocationId { get; set; }
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}

