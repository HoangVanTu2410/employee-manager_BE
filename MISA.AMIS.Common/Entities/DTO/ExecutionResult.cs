using MISA.AMIS.Common.Enums;

namespace MISA.AMIS.Common.Entities
{
    /// <summary>
    /// Dữ liệu trả về khi thực thi xong
    /// </summary>
    public class ExecutionResult
    {
        /// <summary>
        /// Trạng thái thực thi
        /// </summary>
        public ActionStatus ActionStatus { get; set; }

        /// <summary>
        /// Mã lỗi khi thực thi thất bại
        /// </summary>
        public ErrorCode? ErrorCode { get; set; }

        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public object? ResultData { get; set; }
    }
}
