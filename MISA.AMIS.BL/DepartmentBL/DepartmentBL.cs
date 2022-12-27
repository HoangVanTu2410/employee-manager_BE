using MISA.AMIS.Common.Entities;
using MISA.AMIS.DL;

namespace MISA.AMIS.BL
{
    /// <summary>
    /// Tầng BL cho lớp Department
    /// </summary>
    public class DepartmentBL : BaseBL<Department>, IDepartmentBL
    {
        #region Field

        private IDepartmentDL _departmentDL;

        #endregion

        #region Constructor

        public DepartmentBL(IDepartmentDL departmentDL) : base(departmentDL)
        {
            _departmentDL = departmentDL;
        }

        #endregion
    }
}
