using Dapper;
using MISA.AMIS.Common.Constants;
using MySqlConnector;
using System.ComponentModel.DataAnnotations;

namespace MISA.AMIS.DL
{
    /// <summary>
    /// Lớp Base cho tầng DL
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseDL<T> : IBaseDL<T>
    {

        #region Method

        /// <summary>
        /// Lấy danh sách tất cả đối tượng
        /// </summary>
        /// <returns>Danh sách tất cả đối tượng</returns>
        /// Created by: HVTu (20/11/2022)
        public List<T> GetAllRecords()
        {
            // Chuẩn bị tên stored procedure
            string storeProcedureName = string.Format(ProcedureName.PROC_GET_ALL, typeof(T).Name);

            var records = new List<T>();
            // Khởi tạo kết nối tới Database
            try
            {
                using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
                {
                    // Thực hiên gọi vào Database để chạy stored procedure
                    records = (List<T>)mySqlConnection.Query<T>(storeProcedureName, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return records;
        }

        /// <summary>
        /// Lấy 1 đối tượng theo ID
        /// </summary>
        /// <param name="recordID">ID của đối tượng</param>
        /// <returns>1 đối tượng</returns>
        /// Created by: HVTu (20/11/2022)
        public T GetRecordByID(Guid recordID)
        {
            // Chuẩn bị tên stored procedure
            string storeProcedureName = string.Format(ProcedureName.PROC_GET_BY_ID, typeof(T).Name);

            // Chuẩn bị tham số đầu vào cho stored procedure
            var parameters = new DynamicParameters();
            parameters.Add($"@{typeof(T).Name}ID", recordID);

            T record = default(T);
            // Khởi tạo kết nối tới Database
            try
            {
                using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
                {
                    // Thực hiên gọi vào Database để chạy stored procedure
                    record = mySqlConnection.QueryFirstOrDefault<T>(storeProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return record;
        }

        /// <summary>
        /// Thêm mới 1 đối tượng
        /// </summary>
        /// <param name="record">Đối tương cần thêm mới</param>
        /// <returns>Trả về ID của đối tượng mới</returns>
        /// Created by: HVTu (20/11/2022)
        public Guid InsertRecord(T record)
        {
            // Chuẩn bị tên stored procedure
            string storeProcedureName = string.Format(ProcedureName.PROC_INSERT, typeof(T).Name);

            // Chuẩn bị tham số đầu vào cho stored procedure
            var parameters = new DynamicParameters();
            var recordID = Guid.NewGuid();
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(record, null);
                var keyAttribute = property.GetCustomAttributes(typeof(KeyAttribute), false).FirstOrDefault();

                // Nếu không phải là key thì add propertyValue
                // Nếu là key thì add RecordID
                if (keyAttribute == null)
                {
                    parameters.Add($"@{propertyName}", propertyValue);
                }
                else
                {
                    parameters.Add($"@{propertyName}", recordID);
                }
            }

            int numberOfAffectedRows = 0;
            // Khởi tạo kết nối tới Database
            try
            {
                using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
                {
                    // Thực hiên gọi vào Database để chạy stored procedure
                    numberOfAffectedRows = mySqlConnection.Execute(storeProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return (numberOfAffectedRows > 0) ? recordID : Guid.Empty;
        }

        /// <summary>
        /// Sửa thông tin 1 đối tượng
        /// </summary>
        /// <param name="record">Đối tượng cần sửa</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Created by: HVTu (20/11/2022)
        public int UpdateRecord(T record)
        {
            // Chuẩn bị tên stored procedure
            string storeProcedureName = string.Format(ProcedureName.PROC_UPDATE, typeof(T).Name);

            // Chuẩn bị tham số đầu vào cho stored procedure
            var parameters = new DynamicParameters();
            var properties = typeof(T).GetProperties();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(record, null);
                parameters.Add($"@{propertyName}", propertyValue);
            }

            int numberOfAffectedRows = 0;
            // Khởi tạo kết nối tới Database
            try
            {
                using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
                {
                    // Thực hiên gọi vào Database để chạy stored procedure
                    numberOfAffectedRows = mySqlConnection.Execute(storeProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return numberOfAffectedRows;
        }

        /// <summary>
        /// Xóa 1 đối tượng
        /// </summary>
        /// <param name="recordID">ID của đối tượng</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Created by: HVTu (20/11/2022)
        public int DeleteRecord(Guid recordID)
        {
            // Chuẩn bị tên stored procedure
            string storeProcedureName = string.Format(ProcedureName.PROC_DELETE, typeof(T).Name);

            // Chuẩn bị tham số đầu vào cho stored procedure
            var parameters = new DynamicParameters();
            parameters.Add($"@{typeof(T).Name}ID", recordID);

            int numberOfAffectedRows = 0;
            // Khởi tạo kết nối tới Database
            try
            {
                using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
                {
                    // Thực hiên gọi vào Database để chạy stored procedure
                    numberOfAffectedRows = mySqlConnection.Execute(storeProcedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return numberOfAffectedRows;
        }

        /// <summary>
        /// Xóa nhiều đối tượng
        /// </summary>
        /// <param name="recordIDs">Chuỗi ID của các đối tượng cần xóa</param>
        /// <returns>Số bản ghi bị ảnh hưởng</returns>
        /// Created by: HVTu (20/11/2022)
        public int DeleteMultipleRecord(string recordIDs)
        {
            // Chuẩn bị tên stored procedure
            string storeProcedureName = string.Format(ProcedureName.PROC_DELETE_MUTILPLE, typeof(T).Name);

            // Chuẩn bị tham số đầu vào cho stored procedure
            var parameters = new DynamicParameters();
            parameters.Add($"@{typeof(T).Name}IDs", recordIDs);

            int numberOfAffectedRows = 0;
            // Khởi tạo kết nối tới Database
            using (var mySqlConnection = new MySqlConnection(DatabaseContext.ConnectionString))
            {
                mySqlConnection.Open();
                var transaction = mySqlConnection.BeginTransaction();
                try
                {
                    // Thực hiên gọi vào Database để chạy stored procedure
                    numberOfAffectedRows = mySqlConnection.Execute(storeProcedureName, parameters, transaction, commandType: System.Data.CommandType.StoredProcedure);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    transaction.Rollback();
                }
            }
            return numberOfAffectedRows;
        }

        #endregion
    }
}
