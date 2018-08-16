using Eagle.Data;
using Mes.Client.Model.Parm;
using Mes.Client.Service;
using Mes.Client.Service.BE;
using Mes.Client.Utility;
using Mes.Client.Utility.Pages;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web;

namespace Mes.Client.Web.Ashx.KuJiaLe
{
    /// <summary>
    /// chenSplit 的摘要说明
    /// </summary>
    public class chenSplit : BaseHttpHandler
    {
        #region ===================初始加载=====================
        KuJiaLeDesignParm parm;
        public override void ProcessRequest(HttpContext context)
        {
            try
            {
                Request = context.Request;
                Response = context.Response;

                base.ProcessRequest(context);
                string method = Request["Method"] ?? "";
                parm = new KuJiaLeDesignParm(context);
                if (!string.IsNullOrEmpty(method))
                {

                    foreach (MethodInfo mi in this.GetType().GetMethods())
                    {
                        if (mi.Name.ToLower() == method.ToLower())
                        {
                            mi.Invoke(this, null);
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //Response.Write(ex.Message);
            }
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void ToSplit()
        {
            //string designId = Request["designId"] ?? "";



            string cabinetType = Request["CabinetType"] ?? "Wardrobe"; //衣柜、橱柜
            string DesignerID = Request["DesignerID"] ?? "";
            string DesignerNo = Request["DesignerNo"] ?? "";
            string result = "";
            string uid = "meiwu";
            //福满多测试
            string pwd = "pwd123456";

            //string SolutionFileUrl = "";
            //string TaskID = "";

            string ReferenceID = DesignerID;
            string CustomerID = "";

            //string lid = "13760865705";
            //string designId = "3FO4IH68IPBB";

            string lid = "";
            string designId = "";
            string Password = "";
            Database db1 = new Database("BE_RoomDesignerKJLRelation_Proc", "CHENINFO", 0, 0, DesignerNo, "", "");

            using (SqlDataReader dr = db1.ExecuteReader())
            {
                if (dr.Read())
                {
                    uid = dr["CompanyCode"].ToString();
                    lid = dr["UserCode"].ToString();
                    designId = dr["KJLDesignID"].ToString();
                    Password = dr["Password"].ToString();
                    Password = CEncrypt.DecryptString(Password);
                    Password = "pwd123456";
                }
                else
                {
                    throw new Exception(DesignerNo);
                }
            }





            LoginResult restCache;
            //if (CacheHelpers.GetCache("LoginResult") != null)
            //{
            //    restCache = (LoginResult)CacheHelpers.GetCache("LoginResult");
            //    if (!restCache.success)
            //    {
            //        restCache = login3DWeb(uid, lid, pwd);
            //        CacheHelpers.SetCache("LoginResult", restCache, new TimeSpan(23, 0, 0));
            //    }
            //}
            //else
            //{
            //    restCache = login3DWeb(uid, lid, pwd);
            //    CacheHelpers.SetCache("LoginResult", restCache, new TimeSpan(23, 0, 0));
            //}


            restCache = login3DWeb(uid, lid, pwd);

            SplitData sdata = new SplitData();
            try
            {

                Database db = new Database("BE_RoomDesignerKJLRelation_Proc", "CHENSPLID", 0, 0, designId, "", "");
                using (SqlDataReader rd = db.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        sdata.appName = cabinetType;
                        sdata.obsDesignId = designId;
                        sdata.cusOrderId = rd[0].ToString();
                        sdata.cusName = rd[1].ToString(); ;
                        sdata.cusPhone = rd[2].ToString(); ;
                        sdata.cusAddress = rd[3].ToString(); ;
                        sdata.beginOrderData = rd[4].ToString();
                        DesignerID = rd[5].ToString();
                        CustomerID = rd[6].ToString();
                        sdata.endOrderData = "";

                        CookieContainer cc = restCache.msg as CookieContainer;

                        //process=1橱柜;process=2衣柜
                        LoginResult cResult = check3DWeb(cc, 2);
                        if (cResult.success == false)
                        {
                            //throw new Exception(cResult.msg.ToString());
                            WriteMessage(0, cResult.msg.ToString());
                        }
                        //result = split3DWeb(cc, JsonConvert.SerializeObject(sdata));
                        result = submitDesign(uid, lid, Password, sdata);


                        if (result.IndexOf("成功") != -1)
                        {


                            string uploadPath = "/temp/" + DateTime.Now.ToString("yyyyMMdd") + "/SolutionFile/";

                            string ServerPath = Server.MapPath(uploadPath);


                            if (!Directory.Exists(ServerPath))
                            {
                                Directory.CreateDirectory(ServerPath);
                            }




                            string filepath = ServerPath + DesignerNo + ".zip";
                            uploadPath = uploadPath + DesignerNo + ".zip";
                            //FileStream fs = new FileStream(filepath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);

                            string rst = separateBill(uid, lid, Password, filepath, designId, "衣柜");
                            if (rst.IndexOf("false") != -1)
                            {

                                WriteMessage(0, rst);
                            }
                            else
                            {
                                WriteMessage(1, uploadPath);
                            }


                            //LoginResult loginResult = JsonConvert.DeserializeObject<LoginResult>(result);
                            //Uri url = new Uri(loginResult.msg.ToString());
                            //byte[] byteArray = Encoding.UTF8.GetBytes(url.Query.Substring(1));
                            ////Cookie cookieRequest = new Cookie("Cid", "FFFFFFFFFFFFFFFF");

                            ////cookieRequest.Domain = "120.77.62.58";
                            //HttpWebRequest request = WebRequest.Create(loginResult.msg.ToString()) as HttpWebRequest;

                            //request.Method = "POST";
                            //request.KeepAlive = false;
                            //request.ContentType = "application/x-www-form-urlencoded";
                            //request.ContentLength = byteArray.Length;
                            ////request.CookieContainer = new CookieContainer();
                            //request.CookieContainer = cc;
                            //Stream requestStream = request.GetRequestStream();
                            //requestStream.Write(byteArray, 0, byteArray.Length);
                            //requestStream.Flush();
                            //requestStream.Close();

                            //HttpWebResponse response = request.GetResponse() as HttpWebResponse;

                            ////CookieContainer cookieResponse = new CookieContainer();
                            ////cookieResponse.Add(response.Cookies);
                            //Stream stream = response.GetResponseStream();
                            //byte[] bArr = new byte[1024];
                            //int size = stream.Read(bArr, 0, (int)bArr.Length);



                            //string uploadPath = "/temp/" + DateTime.Now.ToString("yyyyMMdd") + "/SolutionFile/";

                            //string ServerPath = Server.MapPath(uploadPath);


                            //if (!Directory.Exists(ServerPath))
                            //{
                            //    Directory.CreateDirectory(ServerPath);
                            //}




                            //string filepath = ServerPath + DesignerNo + ".zip";
                            //uploadPath = uploadPath + DesignerNo + ".zip";
                            //FileStream fs = new FileStream(filepath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                            //while (size > 0)
                            //{
                            //    //stream.Write(bArr, 0, size);
                            //    fs.Write(bArr, 0, size);
                            //    size = stream.Read(bArr, 0, (int)bArr.Length);
                            //}
                            //fs.Close();
                            //stream.Close();


                        }
                        else
                        {
                            WriteMessage(0, result);
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.ToString());
            }
            //Response.Write(result);


        }

        public void SendSplit()
        {
            string cabinetType = Request["CabinetType"] ?? "Wardrobe"; //衣柜、橱柜
            string DesignID = Request["DesignID"] ?? "";
            try
            {

                Database db = new Database("BE_PartnerTask_Proc", "SENDSPLIT", 0, 0, DesignID, "", "");
                int result = db.ExecuteNoQuery();
                if (result > 0)
                {
                    WriteMessage(1, "提交成功！");
                }
                else
                {
                    Response.Write("");
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        // 用FileStream写文件
        public static void FileStreamWriteFile(string filePath, string str)
        {
            byte[] byData;
            char[] charData;
            try
            {
                FileStream nFile = new FileStream(filePath + "love.txt", FileMode.Create);
                //获得字符数组
                charData = str.ToCharArray();
                //初始化字节数组
                byData = new byte[charData.Length];
                //将字符数组转换为正确的字节格式
                Encoder enc = Encoding.UTF8.GetEncoder();
                enc.GetBytes(charData, 0, charData.Length, byData, 0, true);
                nFile.Seek(0, SeekOrigin.Begin);
                nFile.Write(byData, 0, byData.Length);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string HttpDownloadFile(string url, string path)
        {
            // 设置参数
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            //发送请求并获取相应回应数据
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            Stream responseStream = response.GetResponseStream();

            //创建本地文件写入流
            Stream stream = new FileStream(path, FileMode.Create);

            byte[] bArr = new byte[1024];
            int size = responseStream.Read(bArr, 0, (int)bArr.Length);
            while (size > 0)
            {
                stream.Write(bArr, 0, size);
                size = responseStream.Read(bArr, 0, (int)bArr.Length);
            }
            stream.Close();
            responseStream.Close();
            return path;
        }

        public void StreamToFile(Stream stream, string fileName)
        {
            // 把 Stream 转换成 byte[]   
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始   
            stream.Seek(0, SeekOrigin.Begin);

            // 把 byte[] 写入文件   
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(bytes);
            bw.Close();
            fs.Close();
        }

        internal class LoginResult
        {
            public bool success { get; set; }
            public object msg { get; set; }
        }
        private LoginResult login3DWeb(string uid, string lid, string pwd)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(String.Format("action=login&userName={0}&loginName={1}&loginPwd={2}", uid, lid, pwd));

            HttpWebRequest request = WebRequest.Create("http://120.77.62.58:51404/ashx/users.ashx") as HttpWebRequest;

            request.Method = "POST";
            request.KeepAlive = false;
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            request.CookieContainer = new CookieContainer();
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(byteArray, 0, byteArray.Length);
            requestStream.Flush();
            requestStream.Close();

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            CookieContainer cookieResponse = new CookieContainer();
            cookieResponse.Add(response.Cookies);
            Stream instream = response.GetResponseStream();
            StreamReader sr = new StreamReader(instream, Encoding.UTF8);
            string result = sr.ReadToEnd();

            sr.Close();
            response.Close();

            LoginResult loginResult = JSONHelper.DeserializeJsonToObject<LoginResult>(result);
            if (loginResult.success)
            {
                loginResult.msg = cookieResponse;
            }
            else if (loginResult.msg.ToString().Equals("expire"))
            {
                loginResult.msg = "你的帐号已经到期，请联系管理员续费，谢谢！";
            }
            return loginResult;
        }

        internal class SplitData
        {
            public string appName { get; set; }		//橱柜："Cabinet"；衣柜："Wardrobe";
            public string obsDesignId { get; set; }	//酷家乐方案ID
            //美屋扩展
            public string compName { get; set; }        //公司名称
            public string cusOrderId { get; set; }      //订单号
            public string cusName { get; set; }         //客户名称
            public string cusPhone { get; set; }        //客户电话
            public string cusAddress { get; set; }      //客户地址
            public string beginOrderData { get; set; }  //下单日期
            public string endOrderData { get; set; }    //交货日期

        }

        private string split3DWeb(CookieContainer cookieLogin, string sdata)
        {

            byte[] byteArray2 = Encoding.UTF8.GetBytes(sdata);

            HttpWebRequest request2 = WebRequest.Create("http://120.77.62.58:51404/ashx/splitkjl.ashx") as HttpWebRequest;

            request2.Method = "POST";
            request2.KeepAlive = false;
            request2.ContentType = "text/plain;charset=utf-8";
            request2.ContentLength = byteArray2.Length;
            request2.CookieContainer = cookieLogin;
            Stream requestStream2 = request2.GetRequestStream();
            requestStream2.Write(byteArray2, 0, byteArray2.Length);
            requestStream2.Flush();
            requestStream2.Close();

            HttpWebResponse response2 = request2.GetResponse() as HttpWebResponse;
            Stream instream2 = response2.GetResponseStream();
            StreamReader sr2 = new StreamReader(instream2, Encoding.UTF8);
            string result2 = sr2.ReadToEnd();
            sr2.Close();
            response2.Close();

            return result2;
        }

        private LoginResult check3DWeb(CookieContainer cookieLogin, int process)
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(String.Format("action=check&process={0}", process));

            HttpWebRequest request = WebRequest.Create("http://120.77.62.58:51404/ashx/users.ashx") as HttpWebRequest;

            request.Method = "POST";
            request.KeepAlive = false;
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            request.CookieContainer = cookieLogin;
            Stream requestStream = request.GetRequestStream();
            requestStream.Write(byteArray, 0, byteArray.Length);
            requestStream.Flush();
            requestStream.Close();

            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            CookieContainer cookieResponse = new CookieContainer();
            cookieResponse.Add(response.Cookies);
            Stream instream = response.GetResponseStream();
            StreamReader sr = new StreamReader(instream, Encoding.UTF8);
            string result = sr.ReadToEnd();

            sr.Close();
            response.Close();

            LoginResult loginResult = JSONHelper.DeserializeJsonToObject<LoginResult>(result);// JsonConvert.DeserializeObject<LoginResult>(result);
            if (loginResult.success)
            {
                loginResult.msg = cookieResponse;
            }
            else if (loginResult.msg.ToString().Equals("expire"))
            {
                loginResult.msg = "你的帐号已经到期，请联系管理员续费，谢谢！";
            }
            return loginResult;
        }

        //提交方案：
        private string submitDesign(string unit, string UserCode, string password, SplitData sdata)
        {
            object cookieLogin = null;
            //LoginResult loginResult = login3DWeb("meiwu"/*单位名称*/, "15915831930"/*手机号*/, "pwd123456"/*密码*/);
            LoginResult loginResult = login3DWeb(unit/*单位名称*/, UserCode/*手机号*/, password/*密码*/);
            if (loginResult.success)
                cookieLogin = loginResult.msg as CookieContainer;
            else
                return loginResult.msg.ToString();

            //SplitData sdata = new SplitData();
            //填充sdata信息
            //...

            string result = split3DWeb(cookieLogin as CookieContainer, JSONHelper.SerializeObject(sdata));
            LoginResult splitResult = JSONHelper.DeserializeJsonToObject<LoginResult>(result);
            // MessageBox.Show(splitResult.msg);
            return splitResult.msg.ToString();
        }

        // 一键拆单：
        private string separateBill(string uid, string UserCode, string password, string path, string KJLDesignID, string type)
        {
            object cookieLogin = null;
            LoginResult loginResult = login3DWeb(uid/*单位名称*/, UserCode/*手机号*/, password/*密码*/);
            if (loginResult.success)
                cookieLogin = loginResult.msg as CookieContainer;
            else
                return "false";

            //string woodType = "橱柜" ? 1 : 2;
            //1  "Cabinet" :2 "Wardrobe"
            int woodTypeNum = 0;
            string woodTypeStr = "";
            if (type == "橱柜")
            {
                woodTypeNum = 1;
                woodTypeStr = "Cabinet";
            }
            else if (type == "衣柜")
            {
                woodTypeNum = 2;
                woodTypeStr = "Wardrobe";
            }
            loginResult = check3DWeb(cookieLogin as CookieContainer, woodTypeNum);
            if (loginResult.success)
                cookieLogin = loginResult.msg as CookieContainer;
            else
                return "false";

            object sdata = new { appName = woodTypeStr, obsDesignId = KJLDesignID };

            string result = split3DWeb(cookieLogin as CookieContainer,JSONHelper.SerializeObject(sdata));
            LoginResult splitResult = new LoginResult();
            try
            {
                splitResult =JSONHelper.DeserializeJsonToObject<LoginResult>(result);
            }
            catch (Exception)
            {
                return result + "/false";
            }

            if (splitResult.success)
            {
                Uri uri = new Uri(splitResult.msg.ToString());
                string queryStr = uri.Query.TrimStart('?');
                byte[] byteArray = Encoding.UTF8.GetBytes(queryStr);

                HttpWebRequest request = WebRequest.Create(splitResult.msg.ToString()) as HttpWebRequest;
                request.Method = "POST";
                request.KeepAlive = false;
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;
                request.CookieContainer = cookieLogin as CookieContainer;
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(byteArray, 0, byteArray.Length);
                requestStream.Flush();
                requestStream.Close();

                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                Stream instream = response.GetResponseStream();
                StreamReader sr = new StreamReader(instream, Encoding.ASCII);

                byte[] bArr = new byte[1024];
                FileStream fs = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
                int size = instream.Read(bArr, 0, (int)bArr.Length);
                while (size > 0)
                {
                    fs.Write(bArr, 0, size);
                    size = instream.Read(bArr, 0, (int)bArr.Length);
                }
                fs.Close();

                sr.Close();
                response.Close();
                return "success";
            }
            else
                return splitResult.msg.ToString() + "/false";
            //    MessageBox.Show(splitResult.msg);
        }

        //--------------------------------------------以上代码（必须传递参数（订单号 客户名  客户电话 客户地址    下单日期 交货日期）


        //cookieLogin:cookie令牌


        //--------------SplitData 对象
        //appName ：类型["Cabinet" 橱柜: "Wardrobe"衣柜;(appName )]

        //obsDesignId ：方案ID

        //返回：result2; json（成功状态）
    }
}