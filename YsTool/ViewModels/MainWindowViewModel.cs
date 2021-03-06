﻿using FrameWork.Utility;
using FrameWork.Models;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using YsTool.Consts;
using YsTool.Pages;
using YsTool.ViewModels.Base;

namespace YsTool.ViewModels
{
    /// <summary>
    /// 主画面
    /// </summary>
    public class MainWindowViewModel : BaseViewModel
    {
        /// <summary>
        /// 主Page
        /// </summary>
        public Page MainPage { get; set; } = new UI003();

        /// <summary>
        /// Wbs 菜单
        /// </summary>
        public ObservableCollection<EnumItem> WbsItems { get; set; }

        /// <summary>
        /// App 菜单
        /// </summary>
        public ObservableCollection<EnumItem> AppItems { get; set; }

        /// <summary>
        /// Web 菜单
        /// </summary>
        public ObservableCollection<EnumItem> WebItems { get; set; }

        /// <summary>
        /// Web 菜单
        /// </summary>
        public ObservableCollection<EnumItem> CodItems { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        public MainWindowViewModel()
        {
            // Wbs 菜单
            WbsItems = new ObservableCollection<EnumItem>()
            {
                PageEnum.UI001.GetItem(), // 
                PageEnum.UI002.GetItem(), //
                PageEnum.UI003.GetItem(), //
            };
            // App 菜单
            AppItems = new ObservableCollection<EnumItem>()
            {
                PageEnum.UI101.GetItem(), //
                PageEnum.UI102.GetItem(), //
            };
            // Web 菜单
            WebItems = new ObservableCollection<EnumItem>()
            {
                PageEnum.UI201.GetItem(), //
                PageEnum.UI202.GetItem(), //
            };
            // Code 菜单
            CodItems = new ObservableCollection<EnumItem>()
            {
                PageEnum.UI902.GetItem(), //
                PageEnum.UI903.GetItem(), //
            };
        }
    }
}
