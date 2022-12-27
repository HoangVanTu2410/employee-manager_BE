using Dapper;
using MISA.AMIS.Common.Constants;
using MISA.AMIS.Common.Entities;
using MySqlConnector;

namespace MISA.AMIS.DL
{
    /// <summary>
    /// DL cho lớp Employee
    /// </summary>
    public class EmployeeDL : BaseDL<Employee>, IEmployeeDL
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
        public PagingResult<Employee> GetEmployeeByFilter(
            string? keyword,
            int offset,
            int limit, 
            string? sort)
        {
            // Chuẩn bị tên stored procedure
            string storeProcedureName = string.Format(ProcedureName.PROC_GET_PAGING, typeof(Employee).Name);

            // Chuẩn bị tham số đầu vào cho stored procedure
            var parameters = new DynamicParameters();
            parameters.Add("@Offset", offset);
            parameters.Add("@Limit", limit);
            parameters.Add("@Sort", sort);
            parameters.Add("@Where", keyword);

            var pagingResult = new PagingResult<Employee>();
            // Khởi tạo kết nối tới Database
            try
            {
                using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
                {
                    // Thực hiên gọi vào Database để chạy stored procedure
                    var result = mySqlConnection.QueryMultiple(storeProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                    pagingResult.Data = result.Read<Employee>().ToList();
                    pagingResult.TotalRecord = result.Read<long>().FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return pagingResult;
        }

        /// <summary>
        /// Lấy mã nhân viên lớn nhất
        /// </summary>
        /// <returns>Mã nhân viên mới</returns>
        /// Created by: HVTu (20/11/2022)
        public string GetMaxEmployeeCode()
        {
            // Chuẩn bị tên stored procedure
            string storeProcedureName = string.Format(ProcedureName.PROC_GET_MAX_CODE, typeof(Employee).Name);

            string employeeMaxCode = "";
            // Khởi tạo kết nối tới Database
            try
            {
                using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
                {
                    // Thực hiên gọi vào Database để chạy stored procedure
                    employeeMaxCode = mySqlConnection.QueryFirstOrDefault<string>(storeProcedureName, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return employeeMaxCode;
        }

        #endregion
    }
}
