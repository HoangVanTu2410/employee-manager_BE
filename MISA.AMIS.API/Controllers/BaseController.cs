using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.AMIS.BL;
using MISA.AMIS.Common.Entities;
using MISA.AMIS.Common.Enums;
using MISA.AMIS.Common.Resources;

namespace MISA.AMIS.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        #region Field

        private IBaseBL<T> _baseBL;

        #endregion

        #region Constructor

        public BaseController(IBaseBL<T> baseBL)
        {
            _baseBL = baseBL;
        }

        #endregion

        #region Method

        /// <summary>
        /// API Lấy danh sách tất cả đối tượng
        /// </summary>
        /// <returns>Danh sách tất cả đối tượng</returns>
        /// Created by: HVTu (20/11/2022)
        [HttpGet]
        public IActionResult GetAllRecords()
        {
            var executionResult = _baseBL.GetAllRecords();
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
        /// API lấy 1 đối tượng theo ID
        /// </summary>
        /// <param name="id">ID của đối tượng</param>
        /// <returns>1 đối tượng</returns>
        /// Created by: HVTu (20/11/2022)
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetRecordByID([FromRoute] Guid id)
        {
            var executionResult = _baseBL.GetRecordByID(id);
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
        /// API thêm mới 1 đối tượng
        /// </summary>
        /// <param name="record">Đối tượng</param>
        /// <returns>ID của đối tượng mới thêm</returns>
        /// Created by: HVTu (20/11/2022)
        [HttpPost]
        public IActionResult InsertRecord([FromBody] T record)
        {
            var executionResult = _baseBL.InsertRecord(record);
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
        /// API sửa thông in 1 đối tượng
        /// </summary>
        /// <param name="record">Đối tượng</param>
        /// <param name="id">ID của đối tượng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateRecord([FromBody] T record, [FromRoute] Guid id)
        {
            var executionResult = _baseBL.UpdateRecord(record);
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
        /// API xóa 1 đối tượng
        /// </summary>
        /// <param name="id">ID của đối tượng</param>
        /// <returns>ID của đối tượng</returns>
        /// Created by: HVTu (20/11/2022)
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteRecord([FromRoute] Guid id)
        {
            var executionResult = _baseBL.DeleteRecord(id);
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
        /// Trả về lỗi cho client
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        protected IActionResult HandleException(Exception ex)
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

        #endregion
    }
}
