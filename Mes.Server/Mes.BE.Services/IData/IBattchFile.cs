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
    [ServiceContract]
    public partial interface IServiceBE
    {
        [OperationContract]
        void SaveBattchFile(Sender sender, SaveBattchFileArgs args);
        [OperationContract]
        SearchResult SearchBattchFile(Sender sender, SearchBattchFileArgs args);
        [OperationContract]
        void DeleteBattchFileByBattchNum_FileName(Sender sender, string BattchNum, string FileName);
        [OperationContract]
        void DeleteBattchFileByFileID(Sender sender, Guid FileID);
        [OperationContract]
        BattchFile GetBattchFile(Sender sender, Guid FileID);
        [OperationContract]
        List<BattchFile> GetBattchFileByBattchNum(Sender sender, string BattchNum);
        [OperationContract]
        bool BattchFileIsDuplicated(Sender sender, BattchFile battchFile);
    }
}
