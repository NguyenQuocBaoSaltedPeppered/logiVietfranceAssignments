namespace PMApp.API.Models.Schemas
{
    public class ProjectDTO
    {
        public string ProjectName {get; set;}
        public string Description {get; set;}
        public string CustomerName {get; set;}
        public DateTime StartDate {get; set;}
        public DateTime EndDate {get; set;}
        public List<ProjectPhase> ProjectPhases {get; set;}
    }
}