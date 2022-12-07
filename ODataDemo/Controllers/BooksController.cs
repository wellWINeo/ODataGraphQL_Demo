using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Shared;

namespace ODataDemo.Controllers;

[Route("/api/books")]
public class BooksController : BaseODataController<Book> { }