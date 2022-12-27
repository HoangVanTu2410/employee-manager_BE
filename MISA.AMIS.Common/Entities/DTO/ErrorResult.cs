using MISA.AMIS.Common.Enums;

namespace MISA.AMIS.Common.Entities
{
    /// <summary>
    /// Dữ liệu trả về client khi gặp lỗi
    /// </summary>
    public class ErrorResult
    {
        /// <summary>
        /// Mã lỗi
        /// </summary>
        public ErrorCode ErrorCode { get; set; }

        /// <summary>
        /// Message trả về cho Dev khi gặp exception
        /// </summary>
        public string DevMsg { get; set; }

        /// <summary>
        /// Message trả về cho người dùng khi gặp exception
        /// </summary>
        public string UserMsg { get; set; }

        /// <summary>
        /// Thông tin chi tiết về lỗi
        /// </summary>
        public object MoreInfo { get; set; }

        /// <summary>
        /// Dấu vết lỗi
        /// </summary>
        public string TraceId { get; set; }
    }
}
