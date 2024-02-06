using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMApp.API.Models;
using PMApp.API.Models.Schemas;
using PMApp.API.Models.Schemas.Bases;

namespace PMApp.API.Services
{
    public interface IProjectService
    {
        /// <summary>
        /// Hàm xử lý lấy danh sách dự án
        /// </summary>
        /// <param name="filter">Điều kiện tìm kiếm</param>
        /// <returns></returns>
        ListOfProject GetProjects(ProjectFilter filter);
        /// <summary>
        /// Hàm tạo dự án mới
        /// </summary>
        /// <param name="projectData">Dữ liệu của dự án cần tạo</param>
        /// <returns></returns>
        ResponseInfo CreateProject(ProjectDTO projectData);
        /// <summary>
        /// Hàm cập nhật dự án
        /// </summary>
        /// <param name="projectData">Dữ liệu mới của dự án cần cập nhật</param>
        /// <param name="projectId">Id dự án cần cập nhật</param>
        /// <returns></returns>
        ResponseInfo UpdateProject(ProjectDTO projectData, Guid projectId);
        /// <summary>
        /// Hàm xoá dự án
        /// </summary>
        /// <param name="projectId">Id dự án cần xoá</param>
        /// <returns></returns>
        ResponseInfo DeleteProject(Guid projectId);
        /// <summary>
        /// Hàm thêm thành viên vào dự án
        /// </summary>
        /// <param name="employeeAdded">Thông tin nhân viên cần được thêm vào giai đoạn của dự án</param>
        /// <param name="projectId">Id dự án cần được thêm vào</param>
        /// <returns></returns>
        ResponseInfo AddEmployee(EmployeeAddedInfo employeeAdded, Guid projectId);
    }
}