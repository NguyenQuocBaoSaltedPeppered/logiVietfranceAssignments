using PMApp.API.Models.Schemas.Bases;

namespace PMApp.API.Models.Schemas
{
    public class Project
    {
        public string Id {get; set;}
        public string ProjectName {get; set;}
        public string Description {get; set;}
        public string CustomerName {get; set;}
        public DateTime StartDate {get; set;}
        public DateTime EndDate {get; set;}
        public List<ProjectPhase> ProjectPhases {get; set;}
    }
    public class ListOfProject : BaseListOfData<Project>
    {

    }
}