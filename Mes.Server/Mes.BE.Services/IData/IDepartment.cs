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
    public partial interface IServiceBE
    {
        [OperationContract]
        Department GetDepartment(Sender sender, Guid departmentID);
        [OperationContract]
        List<Department> GetAllDepartments(Sender sender);
        [OperationContract]
        bool DepartmentIsDuplicated(Sender sender, Department department);
        [OperationContract]
        SearchResult SearchDepartment(Sender sender, SearchDepartmentArgs args);
        [OperationContract]
        void SaveDepartment(Sender sender, SaveDepartmentArgs args);

    }
}
