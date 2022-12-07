using System;
using System.Collections.Generic;

namespace Shared;

public class Location
{
    public Guid Id { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public virtual ICollection<Author> BornAuthors { get; set; }
    public virtual ICollection<Author> LivingAuthors { get; set; }
}