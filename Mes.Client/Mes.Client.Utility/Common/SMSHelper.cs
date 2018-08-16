using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Dysmsapi.Model.V20170525;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mes.Client.Utility
{
    public class SMSHelper
    {
        #region 发送手机验证码
        public static string SendMessage(string phone, string code, out bool IsComplete, string templateCode = "SMS_126570488")
        {
            string message = string.Empty;
            IsComplete = false;
            String product = "Dysmsapi";//短信API产品名称
            String domain = "dysmsapi.aliyuncs.com";//短信API产品域名
            String accessKeyId = "LTAIqNNYVewnP7ky";//你的accessKeyId
            String accessKeySecret = "04BEMRhdUIZCcit1rINbPPjMmtYiHM";//你的accessKeySecret

            StringBuilder jsonBuilder = new StringBuilder();
            jsonBuilder.Append("{");
            jsonBuilder.AppendFormat("\"name\":\"{0}\",\"code\":\"{1}\"", "meiwu", code);
            jsonBuilder.Append("}");

            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", accessKeyId, accessKeySecret);

            DefaultProfile.AddEndpoint("cn-hangzhou", "cn-hangzhou", product, domain);
            IAcsClient acsClient = new DefaultAcsClient(profile);


            SendSmsRequest request = new SendSmsRequest();
            try
            {
                //必填:待发送手机号。支持以逗号分隔的形式进行批量调用
                request.PhoneNumbers = phone;
                //必填:短信签名-可在短信控制台中找到
                request.SignName = "E柜平台";
                //必填:短信模板-可在短信控制台中找到
                //request.TemplateCode = "SMS_126570488";
                request.TemplateCode = templateCode;
                //可选:模板中的变量替换JSON串,如模板内容为"亲爱的${name},您的验证码为${code}"时
                request.TemplateParam = jsonBuilder.ToString();
                //可选:outId为提供给业务方扩展字段,最终在短信回执消息中将此值带回给调用者
                request.OutId = "202";
                //请求失败这里会抛ClientException异常
                SendSmsResponse sendSmsResponse = acsClient.GetAcsResponse(request);

                switch (sendSmsResponse.Code.Trim())
                {
                    case "OK":
                        message = "验证码发生成功";
                        IsComplete = true;
                        break;
                    case "isv.BUSINESS_LIMIT_CONTROL":
                        switch (sendSmsResponse.Message.Trim())
                        {
                            case "触发小时级流控Permits:5":
                                message = "您今天使用验证码短信的次数大于5次 暂无法继续发送 请明天再试"; //5条/小时 1条/分钟  
                                break;
                            case "触发分钟级流控Permits:1":
                                message = "发送验证码过于频繁,请稍后再试";
                                break;
                            case "触发天级流控Permits:10":
                                message = "您今天使用验证码短信的次数大于5次 暂无法继续发送 请明天再试";
                                break;
                            default:
                                message = sendSmsResponse.Message;
                                break;
                        }
                        break;
                    default:
                        message = sendSmsResponse.Message;
                        break;
                }
                return message;
            }
            catch (ServerException ex)
            {
                throw ex;
            }
            catch (ClientException ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 获取随机数
        public static string GetRandom(int lenght = 4)
        {
            string text = "";
            Random rd = new Random();
            for (int i = 1; i <= lenght; i++)
            {
                text += rd.Next(0, 9).ToString();
            }
            return text;
        }
        #endregion
    }
}
