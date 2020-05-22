using FrameWork.Models;
using Kebin1.Utils;
using System.Windows;
using YsTool.Consts;
using YsTool.Pages;
using YsTool.ViewModels;

namespace YsTool
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private MainWindowViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();

            _viewModel = new MainWindowViewModel();
            this.DataContext = _viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuList_PreviewMouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            EnumItem selected = this.MenuListBox.SelectedItem as EnumItem;

            if (selected != null)
            {
                switch ((PageEnum)selected.Index)
                {
                    case PageEnum.UI000:
                        _viewModel.MainPage = new Main();
                        break;
                    case PageEnum.UI001:
                        _viewModel.MainPage = new AppAnalyse();
                        break;
                    case PageEnum.UI002:
                        _viewModel.MainPage = new Group();
                        break;
                    case PageEnum.UI003:
                        _viewModel.MainPage = new User();
                        break;
                    default:
                        break;
                }
            }

            MenuToggleButton.IsChecked = false;
        }
    }
}
