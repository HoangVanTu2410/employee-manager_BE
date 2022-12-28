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
        [Route("Filter")]
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
                return NotFound();
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
                return HandleException();
            }
        }

        /// <summary>
        /// API thêm mới 1 nhân viên
        /// </summary>
        /// <param name="record">Nhân viên</param>
        /// <returns>ID của đối tượng mới thêm</returns>
        /// Created by: HVTu (20/11/2022)
        [HttpPost]
        public override IActionResult InsertRecord([FromBody] Employee record)
        {
            var executionResult = _employeeBL.InsertRecord(record);
            if (executionResult.ActionStatus == ActionStatus.Success)
            {
                return StatusCode(StatusCodes.Status201Created, executionResult.ResultData);
            }
            else
            {
                switch (executionResult.ErrorCode)
                {
                    case ErrorCode.InvalidData:
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult
                        {
                            ErrorCode = ErrorCode.InvalidData,
                            DevMsg = Resources.DevMsg_Exception,
                            UserMsg = Resources.UserMsg_InvalidData,
                            MoreInfo = executionResult.ResultData,
                            TraceId = HttpContext.TraceIdentifier
                        });
                    case ErrorCode.DuplicateCode:
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult
                        {
                            ErrorCode = ErrorCode.DuplicateCode,
                            DevMsg = Resources.DevMsg_Exception,
                            UserMsg = Resources.UserMsg_DuplicateCode,
                            MoreInfo = Resources.MoreInfo_Exception,
                            TraceId = HttpContext.TraceIdentifier
                        });
                    default: return HandleException();
                }
            }
        }

        /// <summary>
        /// API sửa thông tin 1 nhân viên
        /// </summary>
        /// <param name="record">Nhân viên</param>
        /// <param name="id">ID của nhân viên</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        [HttpPut]
        [Route("{id}")]
        public override IActionResult UpdateRecord([FromBody] Employee record, [FromRoute] Guid id)
        {
            var executionResult = _employeeBL.UpdateRecord(record, id);
            if (executionResult.ActionStatus == ActionStatus.Success)
            {
                return Ok(executionResult.ResultData);
            }
            else
            {
                switch (executionResult.ErrorCode)
                {
                    case ErrorCode.InvalidData:
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult
                        {
                            ErrorCode = ErrorCode.InvalidData,
                            DevMsg = Resources.DevMsg_Exception,
                            UserMsg = Resources.UserMsg_InvalidData,
                            MoreInfo = executionResult.ResultData,
                            TraceId = HttpContext.TraceIdentifier
                        });
                    case ErrorCode.DuplicateCode:
                        return StatusCode(StatusCodes.Status400BadRequest, new ErrorResult
                        {
                            ErrorCode = ErrorCode.DuplicateCode,
                            DevMsg = Resources.DevMsg_Exception,
                            UserMsg = Resources.UserMsg_DuplicateCode,
                            MoreInfo = Resources.MoreInfo_Exception,
                            TraceId = HttpContext.TraceIdentifier
                        });
                    default: return HandleException();
                }
            }
        }

        #endregion
    }
}
