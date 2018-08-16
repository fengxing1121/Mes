using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Net;

namespace Mes.Client.Utility
{
    public class DownLoadHelper
    {
        /// <summary>
        /// 参数为虚拟路径
        /// </summary>
        public static string FileNameExtension(string FileName)
        {
            return Path.GetExtension(MapPathFile(FileName));
        }

        /// <summary>
        /// 获取物理地址
        /// </summary>
        public static string MapPathFile(string FileName)
        {
            return HttpContext.Current.Server.MapPath(FileName);
        }

        /// <summary>
        /// 普通下载
        /// </summary>
        /// <param name="FileName">文件虚拟路径</param>
        public static void DownLoadLocalFile(string FileName)
        {
            string destFileName = MapPathFile(FileName);
            if (File.Exists(destFileName))
            {
                FileInfo fi = new FileInfo(destFileName);
                HttpContext.Current.Response.Clear();
                HttpContext.Current.Response.ClearHeaders();
                HttpContext.Current.Response.Buffer = false;
                HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(Path.GetFileName(destFileName), System.Text.Encoding.UTF8));
                HttpContext.Current.Response.AppendHeader("Content-Length", fi.Length.ToString());
                HttpContext.Current.Response.ContentType = "application/octet-stream";
                HttpContext.Current.Response.WriteFile(destFileName);
                HttpContext.Current.Response.Flush();
                HttpContext.Current.Response.End();
            }
        }

        /// <summary>
        /// 分块下载
        /// </summary>
        /// <param name="fileUrl">文件url</param>
        /// <param name="fileName">下载后的文件名</param>
        public static void DownLoad(string fileUrl, string fileName)
        {
            /*=======分块下载=======*/
            long chunkSize = 204800;             //指定块大小 
            byte[] buffer = new byte[chunkSize]; //建立一个200K的缓冲区
            long dataToRead = 0;                 //已读的字节数   
            Stream stream = null;
            WebRequest webReq = null;
            WebResponse webResponse = null;

            try
            {
                //以字符流的形式下载文件
                webReq = WebRequest.Create(new Uri(fileUrl));
                webResponse = webReq.GetResponse();
                dataToRead = webResponse.ContentLength;
                using (WebClient client = new WebClient())
                {
                    stream = client.OpenRead(fileUrl);
                    //添加Http头
                    HttpContext.Current.Response.ContentType = "application/octet-stream";
                    HttpContext.Current.Response.AddHeader("Content-Disposition", "attachement;filename=" + HttpUtility.UrlEncode(fileName));
                    HttpContext.Current.Response.AddHeader("Content-Length", dataToRead.ToString());
                    while (dataToRead > 0)
                    {
                        if (HttpContext.Current.Response.IsClientConnected)
                        {
                            int length = stream.Read(buffer, 0, Convert.ToInt32(chunkSize));
                            HttpContext.Current.Response.OutputStream.Write(buffer, 0, length);
                            HttpContext.Current.Response.Flush();
                            HttpContext.Current.Response.Clear();
                            dataToRead -= length;
                        }
                        else
                        {
                            dataToRead = -1; //防止client失去连接 
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                webResponse.Close();
                webResponse.Dispose();
                if (stream != null) stream.Close();
                HttpContext.Current.Response.Close();
                HttpContext.Current.Response.Clear();
            }
        }
    }
}
