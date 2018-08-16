using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mes.Client.Utility.Extensions
{
    /// <summary>
    /// 字符串增加类
    /// </summary>
    public class StringBuilderPlus
    {
    /// <summary>
    /// 构造函数
    /// </summary>
     public StringBuilderPlus()
     {
         sb = new StringBuilder();
     }

     private StringBuilder sb;
     /// <summary>
     /// 在结尾追加
     /// </summary>
     /// <param name="text"></param>
     /// <returns></returns>
     public string Append(string text)

     {
         sb.Append(text);
         return sb.ToString();
     }

     /// <summary>
     ///  在结尾追加一行
     /// </summary>
     /// <returns></returns>

     public string AppendLine()
     {
         sb.Append("\r\n");
         return sb.ToString();
     }

     /// <summary>
     /// 在结尾追加一行内容
     /// </summary>
     /// <param name="text">输入的文本</param>
     /// <returns></returns>
     public string AppendLine(string text)
     {
         sb.Append(text);
         sb.Append("\r\n");
         return sb.ToString();
     }

     /// <summary>
     /// 添加附带缩进空格字符串累加
     /// </summary>
     /// <param name="spaceNum">空格数</param>
     /// <param name="text">空格文本</param>
     /// <returns></returns>
     public string AppendSpace(int spaceNum, string text)
     {
         sb.Append(Space(spaceNum));
         sb.Append(text);
         return sb.ToString();
     }

     /// <summary>
     /// 添加添加附带缩进空格和空行的字符串累加
     /// </summary>
     /// <param name="spaceNum">空行数</param>
     /// <param name="text">文本</param>
     /// <returns></returns>
     public string AppendSpaceLine(int spaceNum, string text)
     {
          sb.Append(Space(spaceNum));
          sb.Append(text);
          sb.Append("\r\n");
         return  sb.ToString();
     }
     /// <summary>
     /// 删除最后一个字符
     /// </summary>
     /// <param name="strchar">输入字符串</param>
     public void DeleteLastChar(string strchar)
     {
         string str = sb.ToString();
         int length = str.LastIndexOf(strchar);
         if (length > 0)
         {
              sb = new StringBuilder();
              sb.Append(str.Substring(0, length));
         }
     }
     /// <summary>
     /// 删除最一个逗号
     /// </summary>
     public void DeleteLastComma()
     {
         string str =  sb.ToString();
         int length = str.LastIndexOf(",");
         if (length > 0)
         {
              sb = new StringBuilder();
              sb.Append(str.Substring(0, length));
         }
     }
     /// <summary>
     /// 移除指定字符串
     /// </summary>
     /// <param name="start">开始索引位置</param>
     /// <param name="num">长度</param>
     public void Remove(int start, int num)
     {
         sb.Remove(start, num);
     }
     /// <summary>
     /// 添加附带空格缩进
     /// </summary>
     /// <param name="spaceNum">空格数</param>
     /// <returns></returns>
     public string Space(int spaceNum)
     {
         StringBuilder builder = new StringBuilder();
         for (int i = 0; i < spaceNum; i++)
         {
             builder.Append("\t");
         }
         return builder.ToString();
     }
     /// <summary>
     /// 重写ToString()方法
     /// </summary>
     /// <returns></returns>
     public override string ToString()
     {
         return sb.ToString();
     }
     /// <summary>
     /// 获取字符串内容
     /// </summary>
     public StringBuilder Value
     {
         get
         {
             return  sb;
         }
         set {
             sb = value;
         }
     }
    }
}
