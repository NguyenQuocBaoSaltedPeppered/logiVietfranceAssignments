using System.Net;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using PMApp.API.Models;
using PMApp.API.Models.Schemas;
using PMApp.API.Models.Schemas.Bases;
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
    [HttpGet()]
    [ProducesResponseType(typeof(ListOfProject), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Retrieve all projects", Description = "Retrieve all the suitable projects in the database.")]
    public IActionResult GetProjects([FromQuery] ProjectFilter filter)
    {
        ListOfProject returnedData = _projectService.GetProjects(filter);
        return Ok(returnedData);
    }
    /// <summary>
    /// Create a new project
    /// <para>Created at: 06/02/2024</para>
    /// <para>Created by: BaoNQ</para>
    /// </summary>
    [HttpPost()]
    [ProducesResponseType(typeof(ResponseInfo), (int)HttpStatusCode.OK)]
    [SwaggerOperation(Summary = "Create a new project", Description = "Create a new project using the input data of the request")]
    public IActionResult CreateProject([FromBody] ProjectDTO projectData)
    {
        ResponseInfo response = _projectService.CreateProject(projectData);
        return StatusCode(response.StatusCode, response);
    }
    /// <summary>
    /// Delete a project
    /// <para>Created at: 06/02/2024</para>
    /// <para>Created by: BaoNQ</para>
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ResponseInfo), (int)HttpStatusCode.OK)]
    [ProducesResponseType(typeof(ResponseInfo), (int)HttpStatusCode.NotFound)]
    [SwaggerOperation(Summary = "Delete a project", Description = "Delete a project by its id.")]
    public IActionResult DeleteProject([FromRoute] Guid id)
    {
        ResponseInfo response = _projectService.DeleteProject(id);
        return StatusCode(response.StatusCode, response);
    }
}
