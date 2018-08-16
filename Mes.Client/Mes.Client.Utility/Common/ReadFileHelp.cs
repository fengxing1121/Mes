using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Caching;

namespace Mes.Client.Utility.Common
{
    public class ReadFileHelp
    {
        public static string GetTemplet(int Ids, string Path)
        {
            Hashtable table = GetResource(Ids, Path);

            if (table != null)
            {
                if (table.ContainsKey((int)Ids))
                    return table[(int)Ids].ToString();
                return string.Empty;
            }
            else
                return string.Empty;
        }

        private static Hashtable GetResource(int Ids, string Path)
        {
            Hashtable resources;
            string cacheKey = "ReadTemplate_" + (int)Ids;
            // 尝试从缓存中获取
            if (HttpRuntime.Cache[cacheKey] == null)
            {
                resources = new Hashtable();
                LoadResource(resources, cacheKey, Ids, Path);
            }
            return (Hashtable)HttpRuntime.Cache[cacheKey];
        }

        private static void LoadResource(Hashtable target, string cacheKey, int Ids, string Path)
        {
            string filePath = Path.Replace("/", "\\");
            CacheDependency dp = new CacheDependency(filePath);//监视文件和目录更改情况
            string templet = ReadFileHelp.GetFileText(filePath);
            target[(int)Ids] = templet;
            HttpRuntime.Cache.Insert(cacheKey, target, dp, DateTime.MaxValue, TimeSpan.Zero);
        }

        //Get appointed file virtual path's inner text
        public static string GetFileText(string virtualPath)
        {

            //Read from file
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(HttpContext.Current.Server.MapPath(virtualPath));
            }
            catch
            {
                sr = new StreamReader(virtualPath);

            }
            string strOut = sr.ReadToEnd();
            sr.Close();
            return strOut;

            //
        }

        // Updates the text in a file with the passed in values       
        public static void UpdateFileText(string AbsoluteFilePath, string LookFor, string ReplaceWith)
        {
            string sIn = GetFileText(AbsoluteFilePath);
            string sOut = sIn.Replace(LookFor, ReplaceWith);
            WriteToFile(AbsoluteFilePath, sOut);
        }

        // Writes out a file
        public static void WriteToFile(string AbsoluteFilePath, string fileText)
        {
            StreamWriter sw = new StreamWriter(AbsoluteFilePath, false);
            sw.Write(fileText);
            sw.Close();
        }

        // Append to a file
        public static void AppendToFile(string AbsoluteFilePath, string fileText)
        {
            StreamWriter sw = new StreamWriter(AbsoluteFilePath, true);
            sw.Write(fileText);
            sw.Close();
        }

        public static void CreateFileText(string filePath, string fileText)
        {
            if (File.Exists(filePath))
            {
                WriteToFile(filePath, fileText);
            }
            else
            {
                StreamWriter sw = File.CreateText(filePath);
                sw.Write(fileText);
                sw.Close();
            }
        }

        public static bool FileExists(string path)
        {
            return File.Exists(path);
        }

        //读取配置文件
        public string ReadSetFile(string filename)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filename, System.Text.Encoding.UTF8))
                {
                    string temp = sr.ReadToEnd();
                    sr.Close();
                    return temp;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
            }
        }

        //输出配置文件
        public void WriteSetFile(string filename, string content)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filename, false, System.Text.Encoding.UTF8))
                {
                    sw.Write(content);
                    sw.Close();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            finally
            {
            }
        }

    }
}
