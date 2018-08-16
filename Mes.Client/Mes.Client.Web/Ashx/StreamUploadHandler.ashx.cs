using Mes.Client.Model;
using Mes.Client.Utility;
using Mes.Client.Utility.Pages;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Web;

namespace Mes.Client.Web.Ashx
{
    /// <summary>
    /// StreamUploadHandler 的摘要说明
    /// </summary>
    public class StreamUploadHandler : IHttpHandler
    {
        HttpRequest _request;
        HttpResponse _response;
        HttpServerUtility _server;

        FileHelper _fileHelper = new FileHelper();

        private string _tokenPath //自定义令牌保存目录,
        {
            get
            {
                return string.Format(@"/{0}/{1}/{2}/", "Upload", DateTime.Now.ToString("yyyyMMdd"), "TokenFile");
            }
        }
        private string _filePath//自定义文件保存目录，
        {
            get
            {
                return string.Format(@"/{0}/{1}/{2}/", "Upload", DateTime.Now.ToString("yyyyMMdd"), "RoomDesignerFile");
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            _request = context.Request;
            _response = context.Response;
            _server = context.Server;

            string method = _request["Method"].ToString();

            MethodInfo methodInfo = GetType().GetMethod(method);
            methodInfo.Invoke(this, null);
        }

        public void upload()
        {
            string token = _request.QueryString["token"];
            UploadToken uploadToken = GetTokenInfo(token);

            if (uploadToken != null && uploadToken.size > uploadToken.upsize)
            {
                Stream stream = _request.InputStream;
                if (stream != null && stream.Length > 0)
                {
                    _fileHelper.FileName = uploadToken.name;
                    _fileHelper.FilePath = _server.MapPath(_filePath);
                    _fileHelper.WriteFile(stream);

                    uploadToken.upsize += stream.Length;
                    if (uploadToken.size > uploadToken.upsize)
                    {
                        SetTokenInfo(token, uploadToken);
                    }
                    else
                    {
                        //上传完成后删除令牌信息
                        DelTokenInfo(token);

                        //重命名（解决重复上传时内容叠加）
                        //FileInfo fileinfo = new FileInfo(_server.MapPath(_filePath) + uploadToken.name);
                        //string Rename = string.Format(@"{0}_{1}{2}", Path.GetFileNameWithoutExtension(fileinfo.FullName), DateTime.Now.ToString("mmssffff"), fileinfo.Extension);
                        //fileinfo.MoveTo(_server.MapPath(_filePath) + Rename);
                        //uploadToken.name = Rename;

                        //无需重命名
                        uploadToken.name = uploadToken.name;
                    }
                }
            }
            UploadResult ur = new UploadResult();
            ur.message = "";
            ur.filePath = HttpUtility.UrlEncode(_filePath + uploadToken.name, Encoding.UTF8);
            ur.start = uploadToken.upsize;
            ur.success = true;

            string result = JSONHelper.SerializeObject(ur);
            _response.Write(result);
        }

        /// <summary>
        /// 获取令牌
        /// </summary>
        public void tk()
        {
            UploadToken uploadToken = new UploadToken();

            string name = _request.QueryString["name"];
            string size = _request.QueryString["size"];
            string ext = name.Substring(name.LastIndexOf('.'));
            string token = SimpleEncryptor.MD5(name + size);
            uploadToken.name = name;
            uploadToken.size = string.IsNullOrEmpty(size) ? 0 : int.Parse(size);
            uploadToken.token = token;

            if (!File.Exists(_server.MapPath(_tokenPath + token + ".token")))
            {
                string modified = _request.QueryString["modified"];

                uploadToken.filePath = "";
                uploadToken.modified = modified;

                SetTokenInfo(token, uploadToken);
            }

            TokenResult tokenResult = new TokenResult();
            tokenResult.message = "";
            tokenResult.token = token;
            tokenResult.success = true;

            string result = JSONHelper.SerializeObject(tokenResult); ;

            _response.Write(result);
        }

        private void SetTokenInfo(string token, UploadToken uploadToken)
        {
            _fileHelper.FileName = token + ".token";
            _fileHelper.FilePath = _server.MapPath(_tokenPath);
            _fileHelper.WriteFile(JSONHelper.SerializeObject(uploadToken));
        }

        private UploadToken GetTokenInfo(string token)
        {
            string tokenPath = _tokenPath + token + ".token";
            if (File.Exists(_server.MapPath(tokenPath)))
            {
                _fileHelper.FileName = token + ".token";
                _fileHelper.FilePath = _server.MapPath(_tokenPath);
                UploadToken uploadToken = JSONHelper.DeserializeJsonToObject<UploadToken>(_fileHelper.ReadFile());

                return uploadToken;
            }

            return null;
        }

        private void DelTokenInfo(string token)
        {
            string tokenPath = _tokenPath + token + ".token";
            if (File.Exists(_server.MapPath(tokenPath)))
            {
                _fileHelper.FileName = token + ".token";
                _fileHelper.FilePath = _server.MapPath(_tokenPath);
                _fileHelper.DeleteFile();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}