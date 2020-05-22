using FrameWork.Utility;
using FrameWork.Models;
using Kebin1.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Permissions;
using System.Text;
using System.Windows.Controls;
using YsTool.Consts;
using YsTool.Models;
using YsTool.Pages;
using YsTool.ViewModels.Base;

namespace YsTool.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        public Page MainPage { get; set; } = new Group();

        public EnumItem SelectedItem { get; set; }

        public ObservableCollection<EnumItem> ListItems { get; set; } = new ObservableCollection<EnumItem>(typeof(PageEnum).GetList());

        public MainWindowViewModel()
        {

        }
    }
}
