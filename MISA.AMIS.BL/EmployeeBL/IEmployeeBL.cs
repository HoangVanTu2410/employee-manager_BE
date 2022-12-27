using MISA.AMIS.Common.Entities;

namespace MISA.AMIS.BL
{
    /// <summary>
    /// Interface tầng BL cho lớp Employee
    /// </summary>
    public interface IEmployeeBL : IBaseBL<Employee>
    {
        #region Method

        /// <summary>
        /// Tìm kiếm, phân trang danh sách nhân viên theo điều kiện lọc
        /// </summary>
        /// <param name="keyword">Từ khóa muốn tìm kiếm</param>
        /// <param name="offset">Vị trí bản ghi bắt đầu lấy</param>
        /// <param name="limit">Số lượng bản ghi trên 1 trang</param>
        /// <param name="sort">Tiêu chí sắp xếp</param>
        /// <returns>Đối tượng trả về từ tầng BL</returns>
        /// Created by: HVTu (20/11/2022)
        public ExecutionResult GetEmployeeByFilter(string? keyword, int offset, int limit, string? sort);

        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <returns>Đối tượng trả về từ tầng BL</returns>
        /// Created by: HVTu (20/11/2022)
        public ExecutionResult GetNewEmployeeCode();

        /// <summary>
        /// Validate dữ liệu đầu vào
        /// </summary>
        /// <param name="employee">Đối tượng nhân viên mà client truyền lên</param>
        /// <returns>
        /// Đối tượng chứa kết quả thực thi
        /// </returns>
        /// Created by: HVTu (23/11/2022)
        public ExecutionResult ValidateRequestData(Employee employee);

        #endregion
    }
}
