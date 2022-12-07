using Microsoft.AspNetCore.Mvc;
using Shared;

namespace ODataDemo.Controllers;

[Route("/api/genres")]
public class GenresController : BaseODataController<Genre> { }