using System.Text.Json.Serialization;

namespace MISA.AMIS.Common.Entities
{
    /// <summary>
    /// Lớp Base cho các lớp thực thể, chứa các thuộc tính mặc định cho mỗi thực thể
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Ngày tạo
        /// </summary>
        [JsonPropertyName("CreatedDate")]
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// Người tạo
        /// </summary>
        [JsonPropertyName("CreatedBy")]
        public string? CreatedBy { get; set; }

        /// <summary>
        /// Ngày chỉnh sửa
        /// </summary>
        [JsonPropertyName("ModifiedDate")]
        public DateTime? ModifiedDate { get; set; }

        /// <summary>
        /// Người chỉnh sửa
        /// </summary>
        [JsonPropertyName("ModifiedBy")]
        public string? ModifiedBy { get; set; }
    }
}
