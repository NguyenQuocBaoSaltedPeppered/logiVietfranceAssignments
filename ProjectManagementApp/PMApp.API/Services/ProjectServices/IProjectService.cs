using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMApp.API.Models;
using PMApp.API.Models.Schemas;

namespace PMApp.API.Services
{
    public interface IProjectService
    {
        ListOfProject GetProjects(ProjectFilter filter);
    }
}