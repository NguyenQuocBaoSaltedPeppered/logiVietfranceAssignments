namespace PMApp.API.Models.Schemas
{
    public class Employee
    {
        /// <summary>
        /// Id nhân viên
        /// </summary>
        public string Id {get; set;}
        /// <summary>
        /// Tên nhân viên
        /// </summary>
        /// <value></value>
        public string Name {get; set;}
        /// <summary>
        /// Vai trò nhân viên
        /// </summary>
        /// <value></value>
        public string Role {get; set;}
    }
}