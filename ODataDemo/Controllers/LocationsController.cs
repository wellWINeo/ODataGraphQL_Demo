using Microsoft.AspNetCore.Mvc;
using Shared;

namespace ODataDemo.Controllers;

[Route("/api/locations")]
public class LocationsController : BaseODataController<Location> { }