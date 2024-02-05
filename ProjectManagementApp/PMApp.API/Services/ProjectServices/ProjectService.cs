using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PMApp.API.Models.Schemas;

namespace PMApp.API.Services
{
    public class ProjectService : IProjectService
    {
        public ListOfProject GetProjects()
        {
            const string jsonFilePath = "./Services/DataSeeder.json";
            string jsonData = File.ReadAllText(jsonFilePath);
            List<Project> projects = JsonConvert.DeserializeObject<List<Project>>(jsonData);
            ListOfProject returnedData = new();
            returnedData.Datas = projects;
            // int count = returnedData.Datas.count;
            return returnedData;
        }
    }
}