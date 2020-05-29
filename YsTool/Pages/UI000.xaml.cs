using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using YsTool.Consts;

namespace YsTool.Pages
{
    /// <summary>
    /// Main.xaml の相互作用ロジック
    /// </summary>
    public partial class UI000 : BasePage
    {
        public UI000()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.PageChange(PageEnum.UI002);
        }
    }
}
