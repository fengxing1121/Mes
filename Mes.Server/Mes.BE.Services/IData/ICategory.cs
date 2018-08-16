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
        void SaveCategory(Sender sender, SaveCategoryArgs args);
        [OperationContract]
        Category GetCategoryByParentID_CategoryCode(Sender sender, Guid ParentID, string CategoryCode);
        [OperationContract]
        Category GetCategory(Sender sender, Guid CategoryID);
        [OperationContract]
        List<Category> GetCategoriesByParentID(Sender sender, Guid ParentID);
        [OperationContract]
        SearchResult SearchCategory(Sender sender, SearchCategoryArgs args);
        [OperationContract]
        List<Category> GetCategories(Sender sender);
        [OperationContract]
        List<Category> GetCategoryChildrensByCategoryCode(Sender sender, string CategoryCode);
        [OperationContract]
        void DeleteCategory(Sender sender, Guid CategoryID);
    }
}
