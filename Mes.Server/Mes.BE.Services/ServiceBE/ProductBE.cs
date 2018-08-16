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
        public void SaveProductWarehouse(Sender sender, SaveProductWarehouseArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    ProductWarehouseMain obj = new ProductWarehouseMain();
                    obj.InID = args.ProductWarehouseMain.InID;
                    if (op.LoadProductWarehouseMainByInID(obj) == 0)
                    {
                        args.ProductWarehouseMain.Created = DateTime.Now;
                        args.ProductWarehouseMain.CreatedBy = sender.UserCode + "." + sender.UserName;
                        args.ProductWarehouseMain.Modified = DateTime.Now;
                        args.ProductWarehouseMain.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertProductWarehouseMain(args.ProductWarehouseMain);
                    }
                    else
                    {
                        op.UpdateProductWarehouseMainByInID(args.ProductWarehouseMain);
                    }

                    if (args.ProductWarehouseDetails != null)
                    {
                        op.DeleteProductWarehouseDetailsByInID(args.ProductWarehouseMain.InID);
                        foreach (ProductWarehouseDetail item in args.ProductWarehouseDetails)
                        {
                            item.Created = DateTime.Now;
                            item.CreatedBy = sender.UserCode + "." + sender.UserName;
                            op.InsertProductWarehouseDetail(item);
                        }
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
        public ProductWarehouseMain GetProductWarehouse(Sender sender, Guid InID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    ProductWarehouseMain obj = new ProductWarehouseMain();
                    obj.InID = InID;
                    if (op.LoadProductWarehouseMainByInID(obj) == 0)
                        return null;
                    return obj;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchProductWarehouseMain(Sender sender, SearchProductWarehouseMainArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    return op.SearchProductWarehouseMain(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchProductWarehouseDetail(Sender sender, SearchProductWarehouseDetailArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    return op.SearchProductWarehouseDetail(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }

        public ProductMain GetProductMain(Sender sender, Guid ProductID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    ProductMain obj = new ProductMain();
                    obj.ProductID = ProductID;
                    if (op.LoadProductMainByProductID(obj) == 0)
                        return null;
                    return obj;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public ProductMain GetProductMainByProductCode(Sender sender, string ProductCode)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    ProductMain obj = new ProductMain();

                    obj.ProductCode = ProductCode;
                    if (op.LoadProductMainByProductCode(obj) == 0)
                        return null;
                    return obj;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void SaveProduct(Sender sender, SaveProductArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    ProductMain obj = new ProductMain();
                    obj.ProductID = args.ProductMain.ProductID;
                    if (op.LoadProductMainByProductID(obj) == 0)
                    {
                        args.ProductMain.Created = DateTime.Now;
                        args.ProductMain.CreatedBy = sender.UserCode + "." + sender.UserName;
                        args.ProductMain.Modified = DateTime.Now;
                        args.ProductMain.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertProductMain(args.ProductMain);
                    }
                    else
                    {
                        args.ProductMain.Modified = DateTime.Now;
                        args.ProductMain.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateProductMainByProductID(args.ProductMain);
                    }

                    if (args.Product2Hardwares != null)
                    {
                        op.DeleteProduct2HardwaresByProductID(args.ProductMain.ProductID);
                        foreach (Product2Hardware item in args.Product2Hardwares)
                        {
                            item.Created = DateTime.Now;
                            item.CreatedBy = sender.UserCode + "." + sender.UserName;
                            item.Modified = DateTime.Now;
                            item.ModifiedBy = sender.UserCode + "." + sender.UserName;
                            op.InsertProduct2Hardware(item);
                        }
                    }

                    if (args.ProductDetails != null)
                    {
                        op.DeleteProductDetailsByProductID(args.ProductMain.ProductID);
                        foreach (ProductDetail item in args.ProductDetails)
                        {
                            if (IsProductBarcodeDuplicated(sender, item))
                            {
                                throw new PException("产品条码【{0}】已存在。", item.BarcodeNo);
                            }
                            item.Created = DateTime.Now;
                            item.CreatedBy = sender.UserCode + "." + sender.UserName;
                            item.Modified = DateTime.Now;
                            item.ModifiedBy = sender.UserCode + "." + sender.UserName;
                            op.InsertProductDetail(item);
                        }
                    }

                    if (args.ProductProcessFiles != null)
                    {
                        op.DeleteProductProcessFilesByProductID(args.ProductMain.ProductID);
                        foreach (ProductProcessFile item in args.ProductProcessFiles)
                        {
                            item.Created = DateTime.Now;
                            item.CreatedBy = sender.UserCode + "." + sender.UserName;
                            item.Modified = DateTime.Now;
                            item.ModifiedBy = sender.UserCode + "." + sender.UserName;
                            op.InsertProductProcessFile(item);
                        }
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
        public bool IsProductBarcodeDuplicated(Sender sender, ProductDetail productDetail)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    ProductDetail obj = new ProductDetail();
                    obj.BarcodeNo = productDetail.BarcodeNo;

                    if (op.LoadProductDetailByBarcodeNo(obj) == 0)
                    {
                        return false;
                    }
                    return obj.ProductID != productDetail.ProductID;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchProduct(Sender sender, SearchProductArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchProduct(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public ProductDetail GetProductDetail(Sender sender, Guid ItemID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    ProductDetail obj = new ProductDetail();
                    obj.ItemID = ItemID;
                    if (op.LoadProductDetailByItemID(obj) == 0)
                        return null;
                    return obj;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchProductDetail(Sender sender, SearchProductDetailArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchProductDetail(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public List<ProductProcessFile> GetProductProcessFilesByProductID(Sender sender, Guid ProductID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.LoadProductProcessFilesByProductID(ProductID);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public ProductProcessFile GetProductProcessFile(Sender sender, Guid FileID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    ProductProcessFile obj = new ProductProcessFile();
                    obj.FileID = FileID;
                    if (op.LoadProductProcessFileByFileID(obj) == 0)
                        return null;
                    return obj;
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public void DeleteProduct(Sender sender, Guid ProductID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    op.DeleteProductProcessFilesByProductID(ProductID);
                    op.DeleteProduct2HardwaresByProductID(ProductID);
                    op.DeleteProductDetailsByProductID(ProductID);
                    op.DeleteProductMainByProductID(ProductID);
                    op.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchProductHardware(Sender sender, SearchProduct2HardwareArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchProductHardware(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public SearchResult SearchProductProcessFile(Sender sender, SearchProductProcessFileArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    return op.SearchProductProcessFile(args);
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
                throw ex;
            }
        }
        public ProductDetail GetProductDetailByBarcode(Sender sender, string Barcode)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy())
                {
                    ProductDetail obj = new ProductDetail();
                    obj.BarcodeNo = Barcode;

                    if (op.LoadProductDetailByBarcodeNo(obj) == 0)
                        return null;
                    return obj;
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
