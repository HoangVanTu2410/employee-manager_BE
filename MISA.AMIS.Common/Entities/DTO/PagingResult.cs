namespace MISA.AMIS.Common.Entities
{
    /// <summary>
    /// Dữ liệu trả về khi phân trang
    /// </summary>
    public class PagingResult<T>
    {
        #region Field

		/// <summary>
        /// Tổng số bản ghi thỏa mãn điều kiện
        /// </summary>
        public long TotalRecord { get; set; }

        /// <summary>
        /// Danh sách bản ghi
        /// </summary>
        public List<T> Data { get; set; }

        #endregion

        #region Contructer
        public PagingResult()
        {
            TotalRecord = 0;
            Data = new List<T>();
        }

        #endregion
    }
}
