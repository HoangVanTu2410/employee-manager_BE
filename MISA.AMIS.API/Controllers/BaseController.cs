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
                return HandleException();
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
                return HandleException();
            }
        }

        /// <summary>
        /// API thêm mới 1 đối tượng
        /// </summary>
        /// <param name="record">Đối tượng</param>
        /// <returns>ID của đối tượng mới thêm</returns>
        /// Created by: HVTu (20/11/2022)
        [HttpPost]
        public virtual IActionResult InsertRecord([FromBody] T record)
        {
            var executionResult = _baseBL.InsertRecord(record);
            if (executionResult.ActionStatus == ActionStatus.Success)
            {
                return StatusCode(StatusCodes.Status201Created, executionResult.ResultData);
            }
            else
            {
                return HandleException();
            }
        }

        /// <summary>
        /// API sửa thông tin 1 đối tượng
        /// </summary>
        /// <param name="record">Đối tượng</param>
        /// <param name="id">ID của đối tượng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        [HttpPut]
        [Route("{id}")]
        public virtual IActionResult UpdateRecord([FromBody] T record, [FromRoute] Guid id)
        {
            var executionResult = _baseBL.UpdateRecord(record, id);
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
                return HandleException();
            }
        }

        /// <summary>
        /// Xóa nhiều đối tượng
        /// </summary>
        /// <param name="recordIDs">Chuỗi ID của các đối tượng cần xóa</param>
        /// <returns>Đối tượng trả về từ tầng BL</returns>
        /// Created by: HVTu (20/11/2022)
        [HttpPost]
        [Route("DeleteMany")]
        public IActionResult DeleteMultipleRecord([FromBody] string recordIDs)
        {
            var executionResult = _baseBL.DeleteMultipleRecord(recordIDs);
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
        /// Trả về lỗi cho client
        /// </summary>
        /// <returns>Lỗi server</returns>
        protected IActionResult HandleException()
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
