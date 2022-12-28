using MISA.AMIS.Common.Entities;
using MISA.AMIS.Common.Enums;
using MISA.AMIS.DL;

namespace MISA.AMIS.BL
{
    /// <summary>
    /// Base cho tầng BL
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseBL<T> : IBaseBL<T>
    {
        #region Field

        private IBaseDL<T> _baseDL;

        #endregion

        #region Constructor

        public BaseBL(IBaseDL<T> baseDL)
        {
            _baseDL = baseDL;
        }

        #endregion

        #region Method

        /// <summary>
        /// Lấy danh sách tất cả đối tượng
        /// </summary>
        /// <returns>Đối tượng trả về từ tầng BL</returns>
        /// Created by: HVTu (20/11/2022)
        public ExecutionResult GetAllRecords()
        {
            ExecutionResult result = new ExecutionResult();
            var records = _baseDL.GetAllRecords();
            if (records.Count() > 0)
            {
                result.ActionStatus = ActionStatus.Success;
                result.ResultData = records;
            }
            else
            {
                result.ActionStatus = ActionStatus.Failure;
            }
            return result;
        }

        /// <summary>
        /// Lấy 1 đối tượng theo ID
        /// </summary>
        /// <param name="recordID">ID của đối tượng</param>
        /// <returns>Đối tượng trả về từ tầng BL</returns>
        /// Created by: HVTu (20/11/2022)
        public ExecutionResult GetRecordByID(Guid recordID)
        {
            ExecutionResult result = new ExecutionResult();
            var record = _baseDL.GetRecordByID(recordID);
            if (record != null)
            {
                result.ActionStatus = ActionStatus.Success;
                result.ResultData = record;
            }
            else
            {
                result.ActionStatus = ActionStatus.Failure;
            }
            return result;
        }

        /// <summary>
        /// Thêm mới 1 đối tượng
        /// </summary>
        /// <param name="record">Đối tương cần thêm mới</param>
        /// <returns>Đối tượng trả về từ tầng BL</returns>
        /// Created by: HVTu (20/11/2022)
        public virtual ExecutionResult InsertRecord(T record)
        {
            ExecutionResult result = new ExecutionResult();
            var recordID = _baseDL.InsertRecord(record);
            if (recordID != Guid.Empty)
            {
                result.ActionStatus = ActionStatus.Success;
                result.ResultData = recordID;
            }
            else
            {
                result.ActionStatus = ActionStatus.Failure;
            }
            return result;
        }

        /// <summary>
        /// Sửa thông tin 1 đối tượng
        /// </summary>
        /// <param name="record">Đối tượng cần sửa</param>
        /// <param name="recordID">ID của đối tượng cần sửa</param>
        /// <returns>Đối tượng trả về từ tầng BL</returns>
        /// Created by: HVTu (20/11/2022)
        public virtual ExecutionResult UpdateRecord(T record, Guid recordID)
        {
            ExecutionResult result = new ExecutionResult();
            var numberOfAffectedRows = _baseDL.UpdateRecord(record, recordID);
            if (numberOfAffectedRows > 0)
            {
                result.ActionStatus = ActionStatus.Success;
                result.ResultData = numberOfAffectedRows;
            }
            else
            {
                result.ActionStatus = ActionStatus.Failure;
            }
            return result;
        }

        /// <summary>
        /// Xóa 1 đối tượng
        /// </summary>
        /// <param name="recordID">ID của đối tượng</param>
        /// <returns>Đối tượng trả về từ tầng BL</returns>
        /// Created by: HVTu (20/11/2022)
        public ExecutionResult DeleteRecord(Guid recordID)
        {
            ExecutionResult result = new ExecutionResult();
            var numberOfAffectedRows = _baseDL.DeleteRecord(recordID);
            if (numberOfAffectedRows > 0)
            {
                result.ActionStatus = ActionStatus.Success;
                result.ResultData = numberOfAffectedRows;
            }
            else
            {
                result.ActionStatus = ActionStatus.Failure;
            }
            return result;
        }

        /// <summary>
        /// Xóa nhiều đối tượng
        /// </summary>
        /// <param name="recordIDs">Chuỗi ID của các đối tượng cần xóa</param>
        /// <returns>Đối tượng trả về từ tầng BL</returns>
        /// Created by: HVTu (20/11/2022)
        public ExecutionResult DeleteMultipleRecord(string recordIDs)
        {
            ExecutionResult result = new ExecutionResult();
            var numberOfAffectedRows = _baseDL.DeleteMultipleRecord(recordIDs);
            if (numberOfAffectedRows > 0)
            {
                result.ActionStatus = ActionStatus.Success;
                result.ResultData = numberOfAffectedRows;
            }
            else
            {
                result.ActionStatus = ActionStatus.Failure;
            }
            return result;
        }

        #endregion
    }
}
