using MISA.AMIS.Common.Entities;
using MISA.AMIS.Common.Enums;
using MISA.AMIS.Common.Resources;
using MISA.AMIS.DL;
using System.Text.RegularExpressions;

namespace MISA.AMIS.BL
{
    /// <summary>
    /// Tầng BL cho lớp Employee
    /// </summary>
    public class EmployeeBL : BaseBL<Employee>, IEmployeeBL
    {
        #region Field

        private IEmployeeDL _employeeDL;

        #endregion

        #region Constructor

        public EmployeeBL(IEmployeeDL employeeDL) : base(employeeDL)
        {
            _employeeDL = employeeDL;
        }

        #endregion

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
        public ExecutionResult GetEmployeeByFilter(string? keyword, int offset, int limit, string? sort)
        {
            ExecutionResult queryResult = new ExecutionResult();
            // Lấy danh sách nhân viên thỏa mãn điều kiện lọc
            var pagingResult = _employeeDL.GetEmployeeByFilter(keyword, offset, limit, sort);
            if (pagingResult.TotalRecord > 0)
            {
                queryResult.ActionStatus = ActionStatus.Success;
                queryResult.ResultData = pagingResult;
            }
            else
            {
                queryResult.ActionStatus = ActionStatus.Failure;
            }
            return queryResult;
        }

        /// <summary>
        /// Lấy mã nhân viên mới
        /// </summary>
        /// <returns>Đối tượng trả về từ tầng BL</returns>
        /// Created by: HVTu (20/11/2022)
        public ExecutionResult GetNewEmployeeCode()
        {
            ExecutionResult queryResult = new ExecutionResult();
            // Lấy mã nhân viên lớn nhất trong database
            var employeeMaxCode = _employeeDL.GetMaxEmployeeCode();
            if (!employeeMaxCode.Equals("")) {
                // Sinh mã nhân viên mới
                var positionSuffix = employeeMaxCode.Length - 1;
                while (employeeMaxCode[positionSuffix] >= '0' && employeeMaxCode[positionSuffix] <= '9')
                {
                    positionSuffix--;
                }
                // Tách mã nhân viên thành phần chữ và phần số
                var prifixNewCode = employeeMaxCode.Substring(0, positionSuffix + 1);
                var suffixNewCode = employeeMaxCode.Substring(positionSuffix + 1);
                // Sinh ra phần số tiếp theo
                int newSuffixCode = int.Parse(suffixNewCode) + 1;
                var employeeNewCode = prifixNewCode + newSuffixCode;
                queryResult.ActionStatus = ActionStatus.Success;
                queryResult.ResultData = employeeNewCode;
            }
            else
            {
                queryResult.ActionStatus = ActionStatus.Failure;
            }
            return queryResult;
        }

        /// <summary>
        /// Validate dữ liệu đầu vào
        /// </summary>
        /// <param name="employee">Đối tượng nhân viên mà client truyền lên</param>
        /// <returns>
        /// Đối tượng chứa kết quả thực thi
        /// </returns>
        /// Created by: HVTu (23/11/2022)
        public ExecutionResult ValidateRequestData(Employee employee)
        {
            var result = new ExecutionResult();
            var errors = new List<string>();

            // Validate mã nhân viên: Mã nhân viên phải bắt đầu bằng NV và kết thúc bằng 1 số
            var employeeCode = employee.EmployeeCode;
            var regex = "^NV\\d{1,5}$";
            if (!Regex.IsMatch(employeeCode, regex))
            {
                errors.Add(Resources.EmployeeCode_Incorrect);
            }

            // Validate tên nhân viên: Tên nhân viên không được để trống
            var employeeName = employee.EmployeeName.Trim();
            if (employeeName.Equals(""))
            {
                errors.Add(Resources.EmployeeName_Incorrect);
            }

            // Validate mã phòng ban: ID của phòng ban không được để trống
            var departmentID = employee.DepartmentID;
            if (departmentID.Equals(""))
            {
                errors.Add(Resources.DepartmentID_Incorrect);
            }

            // Nếu có ít nhất 1 dữ liệu không hợp lệ thì trả về lỗi
            if (errors.Count() > 0)
            {
                result.ActionStatus = ActionStatus.Failure;
                result.ErrorCode = ErrorCode.InvalidData;
                result.ResultData = errors;
                return result;
            }

            // Kiểm tra trùng mã
            PagingResult<Employee> recordExist;
            if (employee.EmployeeID == null)
            {
                recordExist = _employeeDL.GetEmployeeByFilter($"EmployeeCode = '{employee.EmployeeCode}'", 1, 0, null);
            }
            else
            {
                recordExist = _employeeDL.GetEmployeeByFilter($"EmployeeCode = '{employee.EmployeeCode}' AND EmployeeID != '{employee.EmployeeID}'", 1, 0, null);
            }
            if (recordExist.TotalRecord > 0)
            {
                // Nếu đã tồn tại nhân viên có mã này thì trả về client lỗi trùng mã
                result.ActionStatus = ActionStatus.Failure;
                result.ErrorCode = ErrorCode.DuplicateCode;
            }
            else
            {
                result.ActionStatus = ActionStatus.Success;
            }
            return result;
        }

        /// <summary>
        /// Thêm mới 1 nhân viên
        /// </summary>
        /// <param name="record">Nhân viên cần thêm mới</param>
        /// <returns>Đối tượng trả về từ tầng BL</returns>
        /// Created by: HVTu (20/11/2022)
        public override ExecutionResult InsertRecord(Employee record)
        {
            ExecutionResult result = new ExecutionResult();
            var resultValidate = ValidateRequestData(record);
            if (resultValidate.ActionStatus == ActionStatus.Failure)
            {
                return resultValidate;
            } 
            var recordID = _employeeDL.InsertRecord(record);
            if (recordID != Guid.Empty)
            {
                result.ActionStatus = ActionStatus.Success;
                result.ResultData = recordID;
            }
            else
            {
                result.ActionStatus = ActionStatus.Failure;
                result.ErrorCode = ErrorCode.Exception;
            }
            return result;
        }

        /// <summary>
        /// Sửa thông tin 1 nhân viên
        /// </summary>
        /// <param name="record">Nhân viên cần sửa</param>
        /// <param name="recordID">ID của nhân viên cần sửa</param>
        /// <returns>Đối tượng trả về từ tầng BL</returns>
        /// Created by: HVTu (20/11/2022)
        public override ExecutionResult UpdateRecord(Employee record, Guid recordID)
        {
            ExecutionResult result = new ExecutionResult();
            record.EmployeeID = recordID;
            var resultValidate = ValidateRequestData(record);
            if (resultValidate.ActionStatus == ActionStatus.Failure)
            {
                return resultValidate;
            }
            var numberOfAffectedRows = _employeeDL.UpdateRecord(record, recordID);
            if (numberOfAffectedRows > 0)
            {
                result.ActionStatus = ActionStatus.Success;
                result.ResultData = numberOfAffectedRows;
            }
            else
            {
                result.ActionStatus = ActionStatus.Failure;
                result.ErrorCode = ErrorCode.Exception;
            }
            return result;
        }

        #endregion
    }
}
