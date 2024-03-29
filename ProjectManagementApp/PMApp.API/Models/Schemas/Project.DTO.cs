namespace PMApp.API.Models.Schemas
{
    public class ProjectDTO
    {
        /// <summary>
        /// Tên dự án
        /// </summary>
        public string ProjectName {get; set;}
        /// <summary>
        /// Mô tả về dự án
        /// </summary>
        public string Description {get; set;}
        /// <summary>
        /// Tên khách hàng
        /// </summary>
        /// <value></value>
        public string CustomerName {get; set;}
        /// <summary>
        /// Ngày bắt đầu
        /// </summary>
        public DateTime StartDate {get; set;}
        /// <summary>
        /// Ngày kết thúc
        /// </summary>
        public DateTime EndDate {get; set;}
        /// <summary>
        /// Các giai đoạn trong dự án
        /// </summary>
        /// <value></value>
        public List<ProjectPhase> ProjectPhases {get; set;}
    }
}