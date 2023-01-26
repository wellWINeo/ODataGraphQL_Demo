using Microsoft.AspNetCore.Mvc;
using Shared;

namespace ODataDemo.Controllers;

[Route("/api/authors")]
public class AuthorsController : BaseODataController<Author> { }
