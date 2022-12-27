namespace MISA.AMIS.Common.Enums
{
    /// <summary>
    /// Mã lỗi trả về cho client
    /// </summary>
    public enum ErrorCode
    {
        /// <summary>
        /// Gặp exception
        /// </summary>
        Exception = 1,

        /// <summary>
        /// Trùng mã
        /// </summary>
        DuplicateCode = 2,

        /// <summary>
        /// Dữ liệu đầu vào không hợp lệ
        /// </summary>
        InvalidData = 3,
    }
}
