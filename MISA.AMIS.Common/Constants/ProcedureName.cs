namespace MISA.AMIS.Common.Constants
{
    public class ProcedureName
    {
        /// <summary>
        /// Template cho procedure lấy tất cả bản ghi
        /// </summary>
        public static string PROC_GET_ALL = "Proc_{0}_GetAll";

        /// <summary>
        /// Template cho procedure lấy bản ghi theo ID
        /// </summary>
        public static string PROC_GET_BY_ID = "Proc_{0}_GetByID";

        /// <summary>
        /// Template cho procedure lấy tất cả bản ghi và tổng số bản ghi có phân trang
        /// </summary>
        public static string PROC_GET_PAGING = "Proc_{0}_GetPaging";

        /// <summary>
        /// Template cho procedure lấy mã bản ghi lớn nhất
        /// </summary>
        public static string PROC_GET_MAX_CODE = "Proc_{0}_GetMaxCode";

        /// <summary>
        /// Template cho procedure thêm mới 1 bản ghi
        /// </summary>
        public static string PROC_INSERT = "Proc_{0}_Insert";

        /// <summary>
        /// Template cho procedure cập nhật 1 bản ghi
        /// </summary>
        public static string PROC_UPDATE = "Proc_{0}_Update";

        /// <summary>
        /// Template cho procedure xóa 1 bản ghi
        /// </summary>
        public static string PROC_DELETE = "Proc_{0}_Delete";

        /// <summary>
        /// Template cho procedure xóa nhiều bản ghi
        /// </summary>
        public static string PROC_DELETE_MUTILPLE = "Proc_{0}_DeleteMultiple";
    }
}
