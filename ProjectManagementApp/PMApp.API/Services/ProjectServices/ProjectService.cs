using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PMApp.API.Enum;
using PMApp.API.Models;
using PMApp.API.Models.Schemas;
using PMApp.API.Models.Schemas.Bases;

namespace PMApp.API.Services
{
    public class ProjectService : IProjectService
    {
        public ProjectService() {
            string jsonFilePath = "./Services/DataSeeder/Project.DataSeeder.json";
            string jsonData = File.ReadAllText(jsonFilePath);
            _initData = JsonConvert.DeserializeObject<List<Project>>(jsonData);
            jsonFilePath = "./Services/DataSeeder/Employee.DataSeeder.json";
            jsonData = File.ReadAllText(jsonFilePath);
            _initEmployee = JsonConvert.DeserializeObject<List<Employee>>(jsonData);
        }
        private List<Project> _initData;
        private List<Employee> _initEmployee;
        public ListOfProject GetProjects(ProjectFilter filter)
        {
            filter ??= new();
            var result = _initData;
            if(!string.IsNullOrEmpty(filter.SearchString))
            {
                result = _initData
                    .Where(project =>
                        project.ProjectName.Contains(filter.SearchString, StringComparison.OrdinalIgnoreCase)
                        || project.Description.Contains(filter.SearchString, StringComparison.OrdinalIgnoreCase)
                        || project.CustomerName.Contains(filter.SearchString, StringComparison.OrdinalIgnoreCase)
                    ).ToList();
            }
            int count = result.Count;
            ListOfProject returnedData = new()
            {
                Paging = new(count, filter.Offset, filter.Limit)
            };
            returnedData.Datas = result
                .Skip((returnedData.Paging.CurrentPage - 1) * returnedData.Paging.PageSize)
                .Take(returnedData.Paging.PageSize)
                .ToList();
            return returnedData;
        }
        public ResponseInfo CreateProject(ProjectDTO projectData)
        {
            ResponseInfo returnedData = new();
            var projectValidate = _initData.Where(project => project.ProjectName == projectData.ProjectName).FirstOrDefault();
            if(projectValidate != null)
            {
                returnedData.StatusCode = 409;
                returnedData.Message = "The project already exists in the system.";
                return returnedData;
            }
            if (projectData.ProjectPhases != null)
            {
                bool invalidPhaseCode = projectData.ProjectPhases.Any(pPhase => !PMAppConstant.PMAppPhases.ContainsKey(pPhase.PhaseCode));
                if(invalidPhaseCode)
                {
                    returnedData.StatusCode = 400;
                    returnedData.Message = "Invalid input";
                    return returnedData;
                }
            }
            Project projectDataSubmit = new(projectData);
            _initData.Add(projectDataSubmit);
            returnedData.StatusCode = 201;
            returnedData.ResponseData.Add("ProjectId", $@"{projectDataSubmit.Id}");
            return returnedData;
        }
        public ResponseInfo UpdateProject(ProjectDTO projectData, Guid projectId)
        {
            ResponseInfo returnedData = new();
            var existingProject = _initData.FirstOrDefault(project => project.Id == projectId);
            if (existingProject == null)
            {
                returnedData.StatusCode = 404;
                returnedData.Message = "Project not found";
                return returnedData;
            }
            var duplicateNameProject = _initData.FirstOrDefault(project => project.Id != projectId && project.ProjectName == projectData.ProjectName);
            if (duplicateNameProject != null)
            {
                returnedData.StatusCode = 409;
                returnedData.Message = "The project already exists in the system.";
                return returnedData;
            }
            if (projectData.ProjectPhases != null)
            {
                bool invalidPhaseCode = projectData.ProjectPhases.Any(pPhase => !PMAppConstant.PMAppPhases.ContainsKey(pPhase.PhaseCode));
                if(invalidPhaseCode)
                {
                    returnedData.StatusCode = 400;
                    returnedData.Message = "Invalid input";
                    return returnedData;
                }
            }
            existingProject.ProjectName = projectData.ProjectName;
            existingProject.Description = projectData.Description;
            existingProject.CustomerName = projectData.CustomerName;
            existingProject.StartDate = projectData.StartDate;
            existingProject.EndDate = projectData.EndDate;
            existingProject.ProjectPhases = projectData.ProjectPhases;
            returnedData.Message = "Editted";
            return returnedData;
        }
        public ResponseInfo DeleteProject(Guid projectId)
        {
            ResponseInfo returnedData = new();
            var projectToRemove = _initData.FirstOrDefault(p => p.Id == projectId);
            if(projectToRemove == null)
            {
                returnedData.StatusCode = 404;
                returnedData.Message = "Project not found";
            }
            else
            {
                _initData.Remove(projectToRemove);
                returnedData.Message = "Deleted";
            }
            return returnedData;
        }
        public ResponseInfo AddEmployee(EmployeeAddedInfo employeeAdded, Guid projectId)
        {
            ResponseInfo returnedData = new();
            var existingProject = _initData.FirstOrDefault(project => project.Id == projectId);
            if (existingProject == null)
            {
                returnedData.StatusCode = 404;
                returnedData.Message = "Project not found";
                return returnedData;
            }
            var existingEmployee = _initEmployee.FirstOrDefault(emp => emp.Id == employeeAdded.EmployeeId);
            if(existingEmployee == null)
            {
                returnedData.StatusCode = 400;
                returnedData.Message = "Invalid input";
                returnedData.ResponseData.Add("EmployeeId", "Not Found");
                return returnedData;
            }
            if(!PMAppConstant.PMAppPhases.ContainsKey(employeeAdded.PhaseCode))
            {
                returnedData.StatusCode = 400;
                returnedData.Message = "Invalid input";
                returnedData.ResponseData.Add("PhaseCode", "Invalid");
                return returnedData;
            }
            var projectPhase = existingProject.ProjectPhases.FirstOrDefault(pPhase => pPhase.PhaseCode == employeeAdded.PhaseCode);
            if(projectPhase == null)
            {
                returnedData.StatusCode = 400;
                returnedData.Message = "Invalid input";
                returnedData.ResponseData.Add("PhaseCode", "Not Found");
                return returnedData;
            }
            var existingEmployeeInPhase = projectPhase.Employees.FirstOrDefault(emp => emp.Id == employeeAdded.EmployeeId);
            if(existingEmployeeInPhase != null)
            {
                returnedData.StatusCode = 409;
                returnedData.Message = "The employee already exists in the project.";
                return returnedData;
            }
            projectPhase.Employees.Add(existingEmployee);
            returnedData.Message = "Added";
            return returnedData;
        }
    }
}