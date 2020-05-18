using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;

namespace Kebin1.Utils
{
    /// <summary>
    /// 画面コード
    /// </summary>
    public enum PageEnum
    {
        [Description("Main"), PageUrl("Page/AppAnalyse.xaml")]
        MAIN,
        [Description("User"), PageUrl("Page/User.xaml")]
        USER,
        [Description("Group"), PageUrl("Page/Group.xaml")]
        GROUP,
        [Description("AppAnalyse"), PageUrl("Page/AppAnalyse.xaml")]
        ANALY,
    }

    /// <summary>
    /// メッセージ
    /// </summary>
    public enum MessageCode
    {
        KEB0000W,
        KEB0001I,
        KEB0002I,
        KEB0003I,
        KEB0004I,
    }

    /// <summary>
    /// 官民区分
    /// </summary>
    public enum KubunCode
    {
        [DBValue("0"), Description("官")]
        CODE_0,
        [DBValue("1"), Description("民")]
        CODE_1,
    }

    /// <summary>
    /// 単価契約区分
    /// </summary>
    public enum UnitPriceContCode
    {
        [DBValue(""), Description("")]
        CODE_ALL,
        [DBValue("0"), Description("通常")]
        CODE_0,
        [DBValue("1"), Description("単価契約")]
        CODE_1,
    }

    /// <summary>
    /// 分割区分
    /// </summary>
    public enum DivisionKubunCode
    {
        [DBValue(""), Description("")]
        CODE_ALL,
        [DBValue("0"), Description("通常")]
        CODE_0,
        [DBValue("1"), Description("分割案件")]
        CODE_1,
    }

    /// <summary>
    /// Enum
    /// </summary>
    public static class EnumUtil
    {
        /// <summary>
        /// EnumのDescriptionを取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="code"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public static ObservableCollection<PageItem> GePagetList(this Type enumType)
        {
            ObservableCollection<PageItem> result = new ObservableCollection<PageItem>();

            foreach (var e in Enum.GetValues(enumType))
            {
                PageItem item = new PageItem();
                item.Code = (PageEnum)e;

                // Description
                object[] objArr = e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (objArr != null && objArr.Length > 0)
                {
                    DescriptionAttribute da = objArr[0] as DescriptionAttribute;
                    item.Name = da.Description;
                }

                // DBValue
                object[] dbValueArr = e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(PageUrlAttribute), true);
                if (dbValueArr != null && dbValueArr.Length > 0)
                {
                    PageUrlAttribute da = dbValueArr[0] as PageUrlAttribute;
                    item.Url = da.Value;
                }

                result.Add(item);
            }

            return result;
        }

        /// <summary>
        /// メッセージ取得
        /// </summary>
        /// <param name="code"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string GetMessage(this MessageCode code, params string[] para)
        {
            //return code.GetDescription(parameters);
            XElement ex = XElement.Load(AppDomain.CurrentDomain.BaseDirectory + @"\Message.xml");
            string value = ex.Elements("Message").Where(e => e.Attribute("Code").Value == code.ToString()).FirstOrDefault().Attribute("Value").Value;

            return para.Length > 0 ? string.Format(value, para) : value;
        }

        /// <summary>
        /// EnumのDescriptionを取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="code"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public static string GetDescription<T>(this T code, params string[] para) where T : Enum
        {
            Type type = code.GetType();
            MemberInfo[] memberInfos = type.GetMember(code.ToString());
            if (memberInfos != null && memberInfos.Length > 0)
            {
                DescriptionAttribute[] attrs = memberInfos[0].GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
                if (attrs != null && attrs.Length > 0)
                {
                    return para.Length > 0 ? string.Format(attrs[0].Description, para) : attrs[0].Description;
                }
            }
            return code.ToString();
        }

        /// <summary>
        /// EnumのDescriptionを取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="code"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public static List<EnumItem> GetList(this Type enumType)
        {
            List<EnumItem> result = new List<EnumItem>();

            foreach (var e in Enum.GetValues(enumType))
            {
                EnumItem item = new EnumItem();

                // Description
                object[] objArr = e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (objArr != null && objArr.Length > 0)
                {
                    DescriptionAttribute da = objArr[0] as DescriptionAttribute;
                    item.Name = da.Description;
                }

                // DBValue
                object[] dbValueArr = e.GetType().GetField(e.ToString()).GetCustomAttributes(typeof(DBValueAttribute), true);
                if (dbValueArr != null && dbValueArr.Length > 0)
                {
                    DBValueAttribute da = dbValueArr[0] as DBValueAttribute;
                    item.Value = da.Value;
                }

                result.Add(item);
            }

            return result;
        }
    }

    /// <summary>
    /// Page URL
    /// </summary>
    public class PageUrlAttribute : Attribute
    {
        /// <summary>
        /// DB中の値
        /// </summary>
        public string Value { get; set; }

        public PageUrlAttribute(string value)
        {
            this.Value = value;
        }
    }

    /// <summary>
    /// DB中の値
    /// </summary>
    public class DBValueAttribute : Attribute
    {
        /// <summary>
        /// DB中の値
        /// </summary>
        public string Value { get; set; }

        public DBValueAttribute(string value)
        {
            this.Value = value;
        }
    }

    /// <summary>
    /// タイトル取得
    /// </summary>
    public class PageItem
    {
        /// <summary> 
        /// タイトル１ 
        /// </summary> 
        public PageEnum Code { set; get; }

        /// <summary> 
        /// タイトル１ 
        /// </summary> 
        public string Name { set; get; }

        /// <summary>
        /// タイトル２
        /// </summary>
        public string Url { get; set; }
    }

    /// <summary>
    /// View用ComboBox Item
    /// </summary>
    public class EnumItem
    {
        /// <summary> 
        /// DB中の値 
        /// </summary> 
        public string Value { set; get; }

        /// <summary>
        /// Description
        /// </summary>
        public string Name { get; set; }
    }
}