using Kebin1.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Permissions;
using System.Text;
using System.Windows.Controls;
using YsTool.Pages;
using YsTool.ViewModels.Base;

namespace YsTool.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public Page MainPage { get; set; } = new Group();

        public PageItem SelectedItem { get; set; }

        public ObservableCollection<PageItem> ListItems { get; set; } = typeof(PageEnum).GePagetList();


        public MainWindowViewModel()
        {

        }
    }
}
