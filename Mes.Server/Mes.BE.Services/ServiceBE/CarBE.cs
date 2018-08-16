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
        public void SaveCar(Sender sender, SaveCarArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    Car obj = new Car();
                    obj.CarID = args.Car.CarID;
                    if (op.LoadCarByCarID(obj) == 0)
                    {
                        args.Car.Created = DateTime.Now;
                        args.Car.CreatedBy = sender.UserCode + "." + sender.UserName;
                        args.Car.Modified = DateTime.Now;
                        args.Car.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.InsertCar(args.Car);
                    }
                    else
                    {
                        args.Car.Modified = DateTime.Now;
                        args.Car.ModifiedBy = sender.UserCode + "." + sender.UserName;
                        op.UpdateCarByCarID(args.Car);
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
        public Car GetCar(Sender sender, Guid CarID)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    Car obj = new Car();
                    obj.CarID = CarID;
                    if (op.LoadCarByCarID(obj) == 0)
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
        public SearchResult SearchCar(Sender sender, SearchCarArgs args)
        {
            try
            {
                using (ObjectProxy op = new ObjectProxy(true))
                {
                    return op.SearchCar(args);
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
