namespace MISA.AMIS.DL
{
    /// <summary>
    /// Interface Base cho tầng DL
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseDL<T>
    {
        #region Method

        /// <summary>
        /// Lấy danh sách tất cả đối tượng
        /// </summary>
        /// <returns>Danh sách tất cả đối tượng</returns>
        /// Created by: HVTu (20/11/2022)
        public List<T> GetAllRecords();

        /// <summary>
        /// Lấy 1 đối tượng theo ID
        /// </summary>
        /// <param name="recordID">ID của đối tượng</param>
        /// <returns>1 đối tượng</returns>
        /// Created by: HVTu (20/11/2022)
        public T GetRecordByID(Guid recordID);

        /// <summary>
        /// Thêm mới 1 đối tượng
        /// </summary>
        /// <param name="record">Đối tương cần thêm mới</param>
        /// <returns>Trả về ID của đối tượng mới</returns>
        /// Created by: HVTu (20/11/2022)
        public Guid InsertRecord(T record);

        /// <summary>
        /// Sửa thông tin 1 đối tượng
        /// </summary>
        /// <param name="record">Đối tượng cần sửa</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Created by: HVTu (20/11/2022)
        public int UpdateRecord(T record);

        /// <summary>
        /// Xóa 1 đối tượng
        /// </summary>
        /// <param name="recordID">ID của đối tượng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Created by: HVTu (20/11/2022)
        public int DeleteRecord(Guid recordID);

        /// <summary>
        /// Xóa nhiều đối tượng
        /// </summary>
        /// <param name="recordIDs">Chuỗi ID của các đối tượng cần xóa</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Created by: HVTu (20/11/2022)
        public int DeleteMultipleRecord(string recordIDs);

        #endregion
    }
}
