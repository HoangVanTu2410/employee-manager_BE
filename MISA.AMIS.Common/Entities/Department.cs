using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MISA.AMIS.Common.Entities
{
    /// <summary>
    /// Phòng ban
    /// </summary>
    public class Department : BaseEntity
    {
        /// <summary>
        /// ID của phòng ban
        /// </summary>
        [Key]
        [JsonPropertyName("DepartmentID")]
        public Guid? DepartmentID { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>
        [JsonPropertyName("DepartmentCode")]
        public string DepartmentCode { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        [JsonPropertyName("DepartmentName")]
        public string DepartmentName { get; set; }
    }
}
