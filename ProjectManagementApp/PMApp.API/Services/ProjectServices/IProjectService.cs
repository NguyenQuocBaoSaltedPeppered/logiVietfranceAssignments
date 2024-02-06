using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMApp.API.Models;
using PMApp.API.Models.Schemas;
using PMApp.API.Models.Schemas.Bases;

namespace PMApp.API.Services
{
    public interface IProjectService
    {
        ListOfProject GetProjects(ProjectFilter filter);
        ResponseInfo CreateProject(ProjectDTO projectData);
        ResponseInfo DeleteProject(Guid projectId);
    }
}