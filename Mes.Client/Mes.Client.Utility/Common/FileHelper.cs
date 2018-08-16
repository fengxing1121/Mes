using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Web;

namespace Mes.Client.Utility
{
    public class FileHelper
    {
        public FileHelper()
        {

        }

        public FileHelper(string fileName, string filePath)
        {
            FileName = fileName;
            FilePath = filePath;
        }
        public FileHelper(string fileName, string filePath, string clientFileName)
        {
            FileName = fileName;
            FilePath = filePath;
            ClientFileName = clientFileName;
        }
        UTF8Encoding utf8 = new UTF8Encoding();

        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string ClientFileName { get; set; }

        /// <summary>
        /// 打开或创建文件。
        /// </summary>
        public void WriteFile(string content)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(FilePath);
            if (!dirInfo.Exists)
            {
                Directory.CreateDirectory(FilePath);
            }
            string fullFileName = FilePath + FileName;
            FileStream fs = null;
            try
            {
                fs = new FileStream(fullFileName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);

                lock (this)
                {
                    byte[] buf;
                    long len;
                    try
                    {
                        buf = utf8.GetBytes(content);
                        len = fs.Length;
                        fs.Lock(0, len);
                        fs.Seek(0, SeekOrigin.End);
                        fs.Write(buf, 0, buf.Length);
                        fs.Unlock(0, len);
                        fs.Flush();
                        fs.Close();
                        fs = null;
                    }
                    catch (Exception er)
                    {
                        throw er;
                    }
                }
            }
            catch (Exception er)
            {
                throw er;
            }
        }

        public void WriteFile(Stream stream)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(FilePath);
            if (!dirInfo.Exists)
            {
                Directory.CreateDirectory(FilePath);
            }
            string fullFileName = FilePath + FileName;
            FileStream fs = null;
            try
            {
                if (File.Exists(fullFileName))
                {
                    fs = File.OpenWrite(fullFileName);
                    //fs = new FileStream(fullFileName, FileMode.Append,
                    //FileAccess.Write, FileShare.Write);
                }
                else
                {
                    fs = new FileStream(fullFileName, FileMode.OpenOrCreate,
                    FileAccess.ReadWrite, FileShare.ReadWrite);
                }

                lock (this)
                {
                    byte[] buf;
                    //long len;
                    try
                    {
                        buf = StreamToBytes(stream);

                        //设定书写的開始位置为文件的末尾  
                        fs.Position = fs.Length;
                        //将待写入内容追加到文件末尾  
                        fs.Write(buf, 0, buf.Length);
                        fs.Flush();
                        fs.Close();
                        //len = fs.Length;
                        //fs.Lock(0, len);
                        //fs.Seek(0, SeekOrigin.End);
                        //fs.Write(buf, 0, buf.Length);
                        //fs.Unlock(0, len);
                        //fs.Flush();
                        //fs.Close();
                        //fs = null;
                    }
                    catch (Exception er)
                    {
                        throw er;
                    }
                }
            }
            catch (Exception er)
            {
                throw er;
            }
        }

        /// <summary> 
        /// 将 Stream 转成 byte[] 
        /// </summary> 
        public byte[] StreamToBytes(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);

            // 设置当前流的位置为流的开始 
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }

        /// <summary> 
        /// 将 byte[] 转成 Stream 
        /// </summary> 
        public Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }

        public string ReadFile()
        {
            string fullFileName = FilePath + FileName;
            StringBuilder sb = new StringBuilder();
            using (System.IO.StreamReader sr = new System.IO.StreamReader(fullFileName))
            {
                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    sb.Append(str);
                }
            }
            return sb.ToString();
        }

        public void DownFile(HttpResponse response)
        {
            try
            {
                //string filePath = FilePath + FileName;//路径

                //response.ContentType = "application/x-zip-compressed";
                //response.AddHeader("Content-Disposition", "attachment;filename="+FileName);
                //response.TransmitFile(filePath);

                //string filePath = FilePath + FileName;//路径
                //FileInfo fileInfo = new FileInfo(filePath);
                //response.Clear();
                //response.ClearContent();
                //response.ClearHeaders();
                //response.AddHeader("Content-Disposition", "attachment;filename=" + ClientFileName);
                //response.AddHeader("Content-Length", fileInfo.Length.ToString());
                //response.AddHeader("Content-Transfer-Encoding", "binary");
                //response.ContentType = "application/octet-stream";
                //response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                //response.WriteFile(fileInfo.FullName);
                //response.Flush();
                //response.End();

                string filePath = FilePath + FileName;//路径
                //以字符流的形式下载文件
                FileStream fs = new FileStream(filePath, FileMode.Open);
                byte[] bytes = new byte[(int)fs.Length];
                fs.Read(bytes, 0, bytes.Length);
                fs.Close();
                response.ContentType = "application/octet-stream";
                response.AddHeader("Content-Disposition", "attachment;   filename=" + HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8));
                response.BinaryWrite(bytes);
                response.Flush();
                response.End();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteFile()
        {
            try
            {
                string fullFilePath = FilePath + FileName;
                if (File.Exists(fullFilePath))
                {
                    File.Delete(fullFilePath);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
