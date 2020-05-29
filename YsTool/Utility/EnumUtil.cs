using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;

namespace Kebin1.Utils
{
    /// <summary>
    /// Enum
    /// </summary>
    public static class EnumUtil
    {
        /// <summary>
        /// メッセージ取得
        /// </summary>
        /// <param name="code"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static string GetMessage(string msgCode, params string[] para)
        {
            //return code.GetDescription(parameters);
            XElement ex = XElement.Load(AppDomain.CurrentDomain.BaseDirectory + @"\Message.xml");
            string value = ex.Elements("Message").Where(e => e.Attribute("Code").Value == msgCode).FirstOrDefault().Attribute("Value").Value;

            return para.Length > 0 ? string.Format(value, para) : value;
        }

        /// <summary>
        /// Titles取得
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        //public static TitleItem GetTitles(this ViewCode code)
        //=> new TitleItem()
        //{
        //    Title = code.GetTitle(),
        //    ViewName = code.GetViewName(),
        //};

        /// <summary>
        /// Title特性取得
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        //public static string GetTitle(this ViewCode code)
        //    => code.GetValue();

        /// <summary>
        /// ViewName特性取得
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        //public static string GetViewName(this ViewCode code)
        //    => code.GetDescription();

        /// <summary>
        /// EnumのDescriptionを取得
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="code"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        //public static List<SelectListItem> GetComboBoxList(this Type enumType)
        //    => (from Enum e in Enum.GetValues(enumType)
        //        select new SelectListItem
        //        {
        //            Value = e.GetValue(),
        //            Text = e.GetDescription()
        //        }).ToList();

        /// <summary>
        /// ComboBoxItem取得
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        //public static List<SelectListItem> GetComboBoxList(this CategoryCode code)
        //    => MvcApplication.CodeList.Where(x => x.category_cd == code.GetValue()).OrderBy(x => x.output_order).ThenBy(x => x.detail_cd).Select(x => new SelectListItem()
        //    {
        //        Value = x.detail_cd,
        //        Text = x.new_detail_name,
        //    }).ToList();

        /// <summary>
        /// Value特性取得
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static string GetValue<T>(this T code) where T : Enum
            => code.GetAttribute<ValueAttribute>()?.Value;

        /// <summary>
        /// Enumの特性を取得(共通)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="code"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public static string GetValue(this object code)
            => code.GetAttribute<ValueAttribute>()?.Value;

        /// <summary>
        /// EnumのDescriptionを取得(廃止)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="code"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public static string GetDescription<T>(this T code) where T : Enum
            => code.GetAttribute<DescriptionAttribute>()?.Description;

        /// <summary>
        /// EnumのDescriptionを取得(廃止)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="code"></param>
        /// <param name="para"></param>
        /// <returns></returns>
        public static string GetDescription(this object code)
            => code.GetAttribute<DescriptionAttribute>()?.Description;

        /// <summary>
        /// GetAttribute
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="e"></param>
        /// <returns></returns>
        private static T GetAttribute<T>(this object code) where T : Attribute
        {
            object[] objArr = code.GetType().GetField(code.ToString()).GetCustomAttributes(typeof(T), true);
            if (objArr != null && objArr.Length > 0)
            {
                return objArr[0] as T;
            }
            return null;
        }
    }

    #region Item

    /// <summary>
    /// タイトル取得
    /// </summary>
    public class TitleItem
    {
        /// <summary> 
        /// タイトル１ 
        /// </summary> 
        public string Title { set; get; }

        /// <summary>
        /// タイトル２
        /// </summary>
        public string ViewName { get; set; }
    }

    #endregion

    #region 特性

    /// <summary>
    /// Base特性
    /// </summary>
    public class BaseAttribute : Attribute
    {
        /// <summary>
        /// 値
        /// </summary>
        public string Value { get; set; }
    }

    /// <summary>
    /// Title特性
    /// </summary>
    public class ValueAttribute : BaseAttribute
    {
        public ValueAttribute(string value)
        {
            this.Value = value;
        }
    }

    #endregion
}