using System.Net;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using PMApp.API.Models;
using PMApp.API.Models.Schemas;
using PMApp.API.Services;

namespace PMApp.API.Controllers;

[ApiController]
[Route("/projects")]
public class ProjectController : ControllerBase
{
    private readonly ILogger<ProjectController> _logger;
    private readonly IProjectService _projectService;

    public ProjectController(ILogger<ProjectController> logger, IProjectService projectService)
    {
        _logger = logger;
        _projectService = projectService;
    }

    /// <summary>
    /// Retrieve all projects
    /// <para>Created at: 05/02/2024</para>
    /// <para>Created by: BaoNQ</para>
    /// </summary>
    /// <response code="200">List of projects</response>
    [HttpGet(Name = "GetProject")]
    [ProducesResponseType(typeof(ListOfProject), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Retrieve all projects", Description = "Retrieve all the suitable projects in the database.\n")]
    public IActionResult GetProjects([FromQuery] ProjectFilter filter)
    {
        ListOfProject returnedData = _projectService.GetProjects(filter);
        return Ok(returnedData);
    }
}
