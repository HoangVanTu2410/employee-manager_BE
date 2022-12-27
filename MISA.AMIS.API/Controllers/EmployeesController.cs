using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.BL;
using MISA.AMIS.Common.Entities;
using MISA.AMIS.Common.Enums;
using MISA.AMIS.Common.Resources;

namespace MISA.AMIS.API.Controllers
{
    public class EmployeesController : BaseController<Employee>
    {
        #region Field

        private IEmployeeBL _employeeBL;

        #endregion

        #region Constructor

        public EmployeesController(IEmployeeBL employeeBL) : base(employeeBL)
        {
            _employeeBL = employeeBL;
        }

        #endregion

        #region Method
        /// <summary>
        /// API tìm kiếm, phân trang danh sách nhân viên theo điều kiện lọc
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
        [HttpGet]
        [Route("filter")]
        public IActionResult GetEmployeeByFilterAndPaging(
            [FromQuery] string? keyword,
            [FromQuery] int offset,
            [FromQuery] int limit,
            [FromQuery] string? sort
            )
        {
            var executionResult = _employeeBL.GetEmployeeByFilter(keyword, offset, limit, sort);
            if (executionResult.ActionStatus == ActionStatus.Success)
            {
                return Ok(executionResult.ResultData);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = ErrorCode.Exception,
                    DevMsg = Resources.DevMsg_Exception,
                    UserMsg = Resources.UserMsg_Exception,
                    MoreInfo = Resources.MoreInfo_Exception,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        /// <summary>
        /// API Lấy mã nhân viên mới
        /// </summary>
        /// <returns>Mã nhân viên mới</returns>
        /// Created by: HVTu (20/11/2022)
        [HttpGet]
        [Route("NewEmployeeCode")]
        public IActionResult GetNewEmployeeCode()
        {
            var executionResult = _employeeBL.GetNewEmployeeCode();
            if (executionResult.ActionStatus == ActionStatus.Success)
            {
                return Ok(executionResult.ResultData);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = ErrorCode.Exception,
                    DevMsg = Resources.DevMsg_Exception,
                    UserMsg = Resources.UserMsg_Exception,
                    MoreInfo = Resources.MoreInfo_Exception,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        #endregion
    }
}
