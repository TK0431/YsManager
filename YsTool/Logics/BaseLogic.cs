using FrameWork.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Navigation;
using System.Linq.Expressions;
using YsTool.Consts;
using Microsoft.Win32;

namespace YsTool.Logics
{
    public class BaseLogic
    {
        public string FileDialog()
        {
            OpenFileDialog dlg = new OpenFileDialog()
            {
                Title = "请选择全局替换文件",
                Filter = "Excel|*.xlsx|所有文件|*.*",
            };

            if (dlg.ShowDialog() != true) return null;

            //Debug.Print(dlg.FileName);

            return dlg.FileName;
        }
    }
}
