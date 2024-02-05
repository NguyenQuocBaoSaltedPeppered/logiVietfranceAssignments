namespace PMApp.API.Models.Schemas
{
    public class ProjectPhase
    {
        public string PhaseCode {get; set;}
        public string PhaseName {get; set;}
        public DateTime StartTime {get; set;}
        public DateTime EndTime {get; set;}
        public List<Employee> Employees {get; set;}
    }
}