using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using YsTool.Logics;
using YsTool.ViewModels.Base;

namespace YsTool.ViewModels
{
    /// <summary>
    /// 用户界面
    /// </summary>
    public class UI002ViewModel : BaseViewModel
    {
        private UI002Logic _logic = new UI002Logic();

        #region 属性

        public ICommand FileReplace { get; set; }

        public ICommand FileAdd { get; set; }

        public ICommand FileOut { get; set; }

        #endregion

        public UI002ViewModel()
        {
            this.FileReplace = new RelayTCommand<UI002ViewModel>(_logic.FileReplace);
        }
    }
}
