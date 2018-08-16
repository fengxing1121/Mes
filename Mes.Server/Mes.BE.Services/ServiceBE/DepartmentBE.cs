using Mes.BE.Objects;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Mes.BE.Services
{
    public partial class ServiceBE : IServiceBE
    {
        #region 部门
        public Department GetDepartment(Sender sender, Guid departmentID)
        {
            using (ObjectProxy op = new ObjectProxy())
            {
                Department dpt = new Department();
                dpt.DepartmentID = departmentID;
                if (op.LoadDepartmentByDepartmentID(dpt) == 0)
                {
                    return null;
                }
                return dpt;
            }
        }
        public List<Department> GetAllDepartments(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadDepartments();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public bool DepartmentIsDuplicated(Sender sender, Department department)
        {
            return DepartmentCodeIsDuplicated(department) || DepartmentNameIsDuplicated(department);
        }
        private bool DepartmentCodeIsDuplicated(Department department)
        {
            using (ObjectProxy op = new ObjectProxy())
            {
                Department dpt = new Department();
                dpt.DepartmentCode = department.DepartmentCode;
                if (op.LoadDepartmentByDepartmentCode(dpt) == 0)
                {
                    return false;
                }
                return dpt.DepartmentID != department.DepartmentID;
            }
        }
        private bool DepartmentNameIsDuplicated(Department department)
        {
            using (ObjectProxy op = new ObjectProxy())
            {
                Department dpt = new Department();
                dpt.DepartmentName = department.DepartmentName;
                if (op.LoadDepartmentByDepartmentName(dpt) == 0)
                {
                    return false;
                }
                return dpt.DepartmentID != department.DepartmentID;
            }
        }
        public SearchResult SearchDepartment(Sender sender, SearchDepartmentArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchDepartment(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void SaveDepartment(Sender sender, SaveDepartmentArgs args)
        {
            try
            {
                if (string.IsNullOrEmpty(args.Department.DepartmentName))
                {
                    throw new CException("部门名称:{0}命名无效，可能存在特殊字符。", args.Department.DepartmentName);
                }

                if (DepartmentIsDuplicated(sender, args.Department))
                {
                    throw new CException("部门名称:{0}已存在，请重新输入。", args.Department.DepartmentName);
                }

                using (ObjectProxy op = new ObjectProxy(true))
                {
                    Department dpt = new Department();
                    dpt.DepartmentID = args.Department.DepartmentID;
                    if (op.LoadDepartmentByDepartmentID(dpt) == 0)
                    {
                        dpt = null;
                    }
                    if (dpt == null)
                    {
                        args.Department.Created = DateTime.Now;
                        args.Department.CreatedBy = sender.UserCode + "." + sender.UserName;
                        args.Department.Modified = DateTime.Now;
                        args.Department.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertDepartment(args.Department);
                    }
                    else
                    {
                        args.Department.Modified = DateTime.Now;
                        args.Department.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateDepartmentByDepartmentID(args.Department);
                    }
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        #endregion
    }
}
