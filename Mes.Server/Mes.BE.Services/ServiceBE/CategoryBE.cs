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
        public void SaveCategory(Sender sender, SaveCategoryArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    Category obj = new Category();
                    obj.CategoryID = args.Category.CategoryID;
                    if (op.LoadCategoryByCategoryID(obj) == 0)
                    {
                        args.Category.Created = DateTime.Now;
                        args.Category.CreatedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        args.Category.Modified = DateTime.Now;
                        args.Category.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.InsertCategory(args.Category);
                    }
                    else
                    {
                        args.Category.Modified = DateTime.Now;
                        args.Category.ModifiedBy = string.Format("{0}.{1}", sender.UserCode, sender.UserName);
                        op.UpdateCategoryByCategoryID(args.Category);
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
        public Category GetCategoryByParentID_CategoryCode(Sender sender, Guid ParentID, string CategoryCode)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    Category obj = new Category();
                    obj.ParentID = ParentID;
                    obj.CategoryCode = CategoryCode;
                    if (op.LoadCategoryByParentID_CategoryCode(obj) == 0)
                    {
                        return null;
                    }
                    return obj;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public Category GetCategory(Sender sender, Guid CategoryID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    Category obj = new Category();
                    obj.CategoryID = CategoryID;
                    if (op.LoadCategoryByCategoryID(obj) == 0)
                    {
                        return null;
                    }
                    return obj;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<Category> GetCategoriesByParentID(Sender sender, Guid ParentID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadCategorysByParentID(ParentID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchCategory(Sender sender, SearchCategoryArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchCategory(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<Category> GetCategories(Sender sender)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadCategorys();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<Category> GetCategoryChildrensByCategoryCode(Sender sender, string CategoryCode)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    List<Category> lists = op.LoadCategorysByCategoryCode(CategoryCode);
                    if (lists.Count > 0)
                    {
                        return op.LoadCategorysByParentID(lists[0].CategoryID);
                    }
                    else
                    {
                        return new List<Category>();
                    }
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void DeleteCategory(Sender sender, Guid CategoryID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    if (op.LoadCategorysByParentID(CategoryID).Count > 0)
                    {
                        throw new Exception("请删除子节点后再删除此节点。");
                    }
                    else
                    {
                        op.DeleteCategoryByCategoryID(CategoryID);
                        op.CommitTransaction();
                    }
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
    }
}
