using MISA.AMIS.Common.Entities;

namespace MISA.AMIS.DL
{
    /// <summary>
    /// Interface tầng DL cho đối tượng Employee
    /// </summary>
    public interface IEmployeeDL : IBaseDL<Employee>
    {
        #region Method

        /// <summary>
        /// Tìm kiếm, phân trang danh sách nhân viên theo điều kiện lọc
        /// </summary>
        /// <param name="keyword">Từ khóa muốn tìm kiếm</param>
        /// <param name="offset">Vị trí bản ghi bắt đầu lấy</param>
        /// <param name="limit">Số lượng bản ghi trên 1 trang</param>
        /// <param name="sort">Tiêu chí sắp xếp</param>
        /// <returns>
        /// Một đối tượng chứa thông tin:
        /// + Tổng số bản ghi thỏa mãn điều kiện
        /// + Danh sách bản ghi trên trang
        /// </returns>
        /// Created by: HVTu (20/11/2022)
        public PagingResult<Employee> GetEmployeeByFilter(string? keyword, int offset, int limit, string? sort);

        /// <summary>
        /// Lấy mã nhân viên lớn nhất
        /// </summary>
        /// <returns>Mã nhân viên mới</returns>
        /// Created by: HVTu (20/11/2022)
        public string GetMaxEmployeeCode();

        #endregion
    }
}
