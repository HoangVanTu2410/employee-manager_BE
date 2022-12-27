using MISA.AMIS.Common.Entities;

namespace MISA.AMIS.BL
{
    /// <summary>
    /// Interface Base cho tầng BL
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseBL<T>
    {
        #region Method

        /// <summary>
        /// Lấy danh sách tất cả đối tượng
        /// </summary>
        /// <returns>Đối tượng trả về từ tầng BL</returns>
        /// Created by: HVTu (20/11/2022)
        public ExecutionResult GetAllRecords();

        /// <summary>
        /// Lấy 1 đối tượng theo ID
        /// </summary>
        /// <param name="recordID">ID của đối tượng</param>
        /// <returns>Đối tượng trả về từ tầng BL</returns>
        /// Created by: HVTu (20/11/2022)
        public ExecutionResult GetRecordByID(Guid recordID);

        /// <summary>
        /// Thêm mới 1 đối tượng
        /// </summary>
        /// <param name="record">Đối tương cần thêm mới</param>
        /// <returns>Đối tượng trả về từ tầng BL</returns>
        /// Created by: HVTu (20/11/2022)
        public ExecutionResult InsertRecord(T record);

        /// <summary>
        /// Sửa thông tin 1 đối tượng
        /// </summary>
        /// <param name="record">Đối tượng cần sửa</param>
        /// <returns>Đối tượng trả về từ tầng BL</returns>
        /// Created by: HVTu (20/11/2022)
        public ExecutionResult UpdateRecord(T record);

        /// <summary>
        /// Xóa 1 đối tượng
        /// </summary>
        /// <param name="recordID">ID của đối tượng</param>
        /// <returns>Đối tượng trả về từ tầng BL</returns>
        /// Created by: HVTu (20/11/2022)
        public ExecutionResult DeleteRecord(Guid recordID);

        /// <summary>
        /// Xóa nhiều đối tượng
        /// </summary>
        /// <param name="recordIDs">Chuỗi ID của các đối tượng cần xóa</param>
        /// <returns>Đối tượng trả về từ tầng BL</returns>
        /// Created by: HVTu (20/11/2022)
        public ExecutionResult DeleteMultipleRecord(string recordIDs);

        #endregion
    }
}
