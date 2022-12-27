using MISA.AMIS.Common.Enums;

namespace MISA.AMIS.Common.Entities
{
    /// <summary>
    /// Dữ liệu trả về khi thực thi xong
    /// </summary>
    public class ExecutionResult
    {
        /// <summary>
        /// Mã kết quả
        /// </summary>
        public ActionStatus ActionStatus { get; set; }

        /// <summary>
        /// Dữ liệu trả về
        /// </summary>
        public object? ResultData { get; set; }
    }
}
