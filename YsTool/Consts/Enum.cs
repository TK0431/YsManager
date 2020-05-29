using FrameWork.Consts;
using System.ComponentModel;

namespace YsTool.Consts
{
    /// <summary>
    /// 画面
    /// </summary>
    public enum PageEnum
    {
        [Description("Main"),Value("Pages/UI000.xaml")]
        UI000,
        [Description("WBS"), Value("Pages/UI001.xaml")]
        UI001,
        [Description("User"), Value("Pages/UI002.xaml")]
        UI002,
        [Description("Group"), Value("Pages/UI003.xaml")]
        UI003,
        [Description("App Analyse"), Value("Pages/UI101.xaml")]
        UI101,
        [Description("App Test"), Value("Pages/UI102.xaml")]
        UI102,
        [Description("Web Analyse"), Value("Pages/UI201.xaml")]
        UI201,
        [Description("Web Test"), Value("Pages/UI202.xaml")]
        UI202,
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
