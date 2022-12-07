using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace ODataDemo.Controllers;

public class BaseODataController<T>: ODataController where T: class
{
    [HttpGet("edm"), ODataAttributeRouting, EnableQuery]
    public IQueryable<T> GetAsync([FromServices] LibraryDbContext context) => context.Set<T>();
}