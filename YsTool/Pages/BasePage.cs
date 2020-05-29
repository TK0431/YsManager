using FrameWork.Utility;
using System;
using System.Windows.Controls;
using YsTool.Consts;

namespace YsTool.Pages
{
    public class BasePage : Page
    {
        protected void PageChange(PageEnum page)
            => NavigationService.Navigate(new Uri(page.GetValue(), UriKind.RelativeOrAbsolute));
    }
}
