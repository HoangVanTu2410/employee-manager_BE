using MISA.AMIS.Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MISA.AMIS.Common.Entities
{
    /// <summary>
    /// Nhân viên
    /// </summary>
    public class Employee : BaseEntity
    {
        /// <summary>
        /// ID của nhân viên
        /// </summary>
        [Key]
        [JsonPropertyName("EmployeeID")]
        public Guid? EmployeeID { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [JsonPropertyName("EmployeeCode")]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        [JsonPropertyName("EmployeeName")]
        public string EmployeeName { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        [JsonPropertyName("DateOfBirth")]
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        [JsonPropertyName("Gender")]
        public Gender Gender { get; set; }

        /// <summary>
        /// ID của phòng ban
        /// </summary>
        [JsonPropertyName("DepartmentID")]
        public Guid DepartmentID { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>
        [JsonPropertyName("DepartmentCode")]
        public string? DepartmentCode { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        [JsonPropertyName("DepartmentName")]
        public string? DepartmentName { get; set; }

        /// <summary>
        /// Số chứng minh nhân dân
        /// </summary>
        [JsonPropertyName("IdentityNumber")]
        public string? IdentityNumber { get; set; }

        /// <summary>
        /// Ngày cấp
        /// </summary>
        [JsonPropertyName("IdentityIssueDate")]
        public DateTime? IdentityIssueDate  { get; set; }

        /// <summary>
        /// Nơi cấp
        /// </summary>
        [JsonPropertyName("IdentityIssuePlace")]
        public string? IdentityIssuePlace { get; set; }

        /// <summary>
        /// Chức danh
        /// </summary>
        [JsonPropertyName("JobPosition")]
        public string? JobPosition { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        [JsonPropertyName("Address")]
        public string? Address { get; set; }

        /// <summary>
        /// Số điện thoại di động
        /// </summary>
        [JsonPropertyName("PhoneNumber")]
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Số điện thoại cố định
        /// </summary>
        [JsonPropertyName("LandlineNumber")]
        public string? LandlineNumber { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [JsonPropertyName("Email")]
        public string? Email { get; set; }

        /// <summary>
        /// Số tài khoản ngân hàng
        /// </summary>
        [JsonPropertyName("BankAccountNumber")]
        public string? BankAccountNumber { get; set; }

        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        [JsonPropertyName("BankName")]
        public string? BankName { get; set; }

        /// <summary>
        /// Chi nhánh ngân hàng
        /// </summary>
        [JsonPropertyName("BankBranchName")]
        public string? BankBranchName { get; set; }
    }
}
