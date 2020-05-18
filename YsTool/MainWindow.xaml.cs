using Kebin1.Utils;
using System.Windows;
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
            PageItem selected = this.MenuListBox.SelectedItem as PageItem;
            if (selected != null)
            {
                switch (selected.Code)
                {
                    case PageEnum.MAIN:
                        _viewModel.MainPage = new Main();
                        break;
                    case PageEnum.ANALY:
                        _viewModel.MainPage = new AppAnalyse();
                        break;
                    case PageEnum.GROUP:
                        _viewModel.MainPage = new Group();
                        break;
                    case PageEnum.USER:
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
