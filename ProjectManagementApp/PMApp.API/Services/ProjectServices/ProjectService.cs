using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PMApp.API.Models;
using PMApp.API.Models.Schemas;

namespace PMApp.API.Services
{
    public class ProjectService : IProjectService
    {
        public ListOfProject GetProjects(ProjectFilter filter)
        {
            filter ??= new();
            const string jsonFilePath = "./Services/DataSeeder/Project.DataSeeder.json";
            string jsonData = File.ReadAllText(jsonFilePath);
            List<Project> projects = JsonConvert.DeserializeObject<List<Project>>(jsonData);
            var result = projects;
            if(!string.IsNullOrEmpty(filter.SearchString))
            {
                result = projects
                    .Where(project =>
                        project.ProjectName.Contains(filter.SearchString, StringComparison.OrdinalIgnoreCase)
                        || project.Description.Contains(filter.SearchString, StringComparison.OrdinalIgnoreCase)
                        || project.CustomerName.Contains(filter.SearchString, StringComparison.OrdinalIgnoreCase)
                    ).ToList();
            }
            int count = result.Count;
            ListOfProject returnedData = new();
            returnedData.Paging = new(count, filter.Offset, filter.Limit);
            returnedData.Datas = result
                .Skip((returnedData.Paging.CurrentPage - 1) * returnedData.Paging.PageSize)
                .Take(returnedData.Paging.PageSize)
                .ToList();
            return returnedData;
        }
    }
}