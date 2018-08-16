using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using MES.Libraries;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mes.Client.Utility
{
    public class ZipHelper
    {

        /// <summary>
        /// 解压缩
        /// </summary>
        /// <param name="zipFilePath"></param>
        /// <returns></returns>
        public static List<string> UnZipFile(string zipFilePath)
        {
            string unZipDir = string.Empty;
            List<string> fileUrl = new List<string>();
            try
            {
                if (!File.Exists(zipFilePath))
                {
                    throw new Exception("指定文件不存在.");
                }
                if (unZipDir == string.Empty)
                {
                    unZipDir = zipFilePath.Replace(Path.GetFileName(zipFilePath), Path.GetFileNameWithoutExtension(zipFilePath));
                }
                if (!unZipDir.EndsWith("/"))
                {
                    unZipDir += "/";
                }
                if (!Directory.Exists(unZipDir))
                {
                    Directory.CreateDirectory(unZipDir);
                }
                using (ZipInputStream zipInputStream = new ZipInputStream(File.OpenRead(zipFilePath)))
                {
                    ZipEntry zipEntry = null;
                    while ((zipEntry = zipInputStream.GetNextEntry()) != null)
                    {
                        string directoryName = Path.GetDirectoryName(zipEntry.Name);
                        string fileName = Path.GetFileName(zipEntry.Name);
                        if (!string.IsNullOrEmpty(directoryName))
                        {
                            Directory.CreateDirectory(unZipDir + directoryName);
                        }
                        if (fileName != string.Empty)
                        {
                            fileUrl.Add(unZipDir + directoryName +"/"+ fileName);
                            using (FileStream streamWrite = File.Create(unZipDir + zipEntry.Name))
                            {
                                int bufferSize = 2048;
                                byte[] buffer = new byte[bufferSize];
                                while (true)
                                {
                                    int bytesRead = zipInputStream.Read(buffer, 0, buffer.Length);
                                    if (bytesRead > 0)
                                    {
                                        streamWrite.Write(buffer, 0, bytesRead);
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
            }
            return fileUrl;
        }

        /// <summary>
        /// 压缩文件
        /// </summary>
        /// <param name="SourcePath">文件路径</param>
        /// <param name="DescZipPath">压缩后文件路径</param>
        public static void CreateZip(string SourcePath, string DescZipPath)
        {
            #region 压缩文件
            try
            {
                using (ZipOutputStream zipStream = new ZipOutputStream(File.Create(DescZipPath)))
                {
                    zipStream.SetLevel(6); //压缩级别 0-9
                    CreateZipFiles(SourcePath, zipStream);
                    zipStream.Finish();
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
            }
            #endregion
        }

        /// <summary>
        /// 递归压缩文件
        /// </summary>
        /// <param name="SourcePath"></param>
        /// <param name="zipStream"></param>
        private static void CreateZipFiles(string SourcePath, ZipOutputStream zipStream)
        {
            #region 递归压缩文件
            Crc32 crc = new Crc32();
            try
            {
                string[] Arrays = Directory.GetFileSystemEntries(SourcePath);
                foreach (string item in Arrays)
                {
                    if (Directory.Exists(item))
                    {
                        //文件夹，递归
                        CreateZipFiles(item, zipStream);
                    }
                    else
                    {
                        //文件，压缩
                        FileStream stream = File.OpenRead(item);
                        byte[] buffer = new byte[stream.Length];
                        stream.Read(buffer, 0, buffer.Length);
                        string tempFile = item.Substring(item.LastIndexOf("\\") + 1);
                        ZipEntry entry = new ZipEntry(tempFile);

                        entry.DateTime = DateTime.Now;
                        entry.Size = stream.Length;
                        stream.Close();
                        crc.Reset();
                        crc.Update(buffer);
                        entry.Crc = crc.Value;
                        zipStream.PutNextEntry(entry);
                        zipStream.Write(buffer, 0, buffer.Length);
                        File.Delete(item);
                    }
                }
            }
            catch (Exception ex)
            {
                PLogger.LogError(ex);
            }
            #endregion
        }
    }
}
