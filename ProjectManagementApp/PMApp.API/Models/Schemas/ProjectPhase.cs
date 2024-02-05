namespace PMApp.API.Models.Schemas
{
    public class ProjectPhase
    {
        /// <summary>
        /// Mã giai đoạn
        /// </summary>
        public string PhaseCode {get; set;}
        /// <summary>
        /// Tên giai đoạn
        /// </summary>
        public string PhaseName {get; set;}
        /// <summary>
        /// Thời gian bắt đầu
        /// </summary>
        public DateTime StartTime {get; set;}
        /// <summary>
        /// Thời gian kết thúc
        /// </summary>
        public DateTime EndTime {get; set;}
        /// <summary>
        /// Danh sách nhân viên thuộc giai đoạn
        /// </summary>
        public List<Employee> Employees {get; set;}
    }
}