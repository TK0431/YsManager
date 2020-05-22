using FrameWork;
using FrameWork.Consts;
using FrameWork.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using YsTool.Models;

namespace YsTool.Consts
{
    /// <summary>
    /// 画面
    /// </summary>
    public enum PageEnum
    {
        [Description("Main"), Value("Page/AppAnalyse.xaml")]
        UI000,
        [Description("User"), Value("Page/User.xaml")]
        UI001,
        [Description("Group"), Value("Page/Group.xaml")]
        UI002,
        [Description("AppAnalyse"), Value("Page/AppAnalyse.xaml")]
        UI003,
    }

    /// <summary>
    /// 语言
    /// </summary>
    public enum LanguageEnum
    {
        [Description("英语")]
        ENG,
        [Description("中文")]
        CNS,
        [Description("日语")]
        JAP,
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
        [Value("0"), Description("官")]
        CODE_0,
        [Value("1"), Description("民")]
        CODE_1,
    }

    /// <summary>
    /// 単価契約区分
    /// </summary>
    public enum UnitPriceContCode
    {
        [Value(""), Description("")]
        CODE_ALL,
        [Value("0"), Description("通常")]
        CODE_0,
        [Value("1"), Description("単価契約")]
        CODE_1,
    }

    /// <summary>
    /// 分割区分
    /// </summary>
    public enum DivisionKubunCode
    {
        [Value(""), Description("")]
        CODE_ALL,
        [Value("0"), Description("通常")]
        CODE_0,
        [Value("1"), Description("分割案件")]
        CODE_1,
    }

}
