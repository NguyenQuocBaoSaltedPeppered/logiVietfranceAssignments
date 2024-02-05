namespace PMApp.API.Models.Schemas
{
    /// <summary>
    /// Thông tin nhân viên dùng để thêm vào một giai đoạn của dự án
    /// </summary>
    public class EmployeeAddedInfo
    {
        /// <summary>
        /// Id nhân viên được thêm vào
        /// </summary>
        public string EmployeeId {get; set;}
        /// <summary>
        /// Mã giai đoạn muốn thêm vào
        /// </summary>
        /// <value></value>
        public string PhaseCode {get; set;}
    }
}