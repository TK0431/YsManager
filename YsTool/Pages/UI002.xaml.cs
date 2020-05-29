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
using YsTool.ViewModels;

namespace YsTool.Pages
{
    /// <summary>
    /// User.xaml の相互作用ロジック
    /// </summary>
    public partial class UI002 : BasePage
    {
        private UI002ViewModel _model;

        public UI002()
        {
            InitializeComponent();

            _model = new UI002ViewModel();
            this.DataContext = _model;
        }
    }
}
