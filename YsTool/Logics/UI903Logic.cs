using System;
using System.Text;
using YsTool.ViewModels;

namespace YsTool.Logics
{
    public class UI903Logic : BaseLogic
    {
        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="model"></param>
        public void GetOut(UI903ViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.In)) return;

            if (string.IsNullOrWhiteSpace(model.LeftTxt) && string.IsNullOrWhiteSpace(model.RightTxt)) return;

            model.Out = string.Empty;
            StringBuilder txt = new StringBuilder();
            foreach (string item in model.In.Split(Environment.NewLine))
            {
                txt.AppendLine(model.LeftTxt + item + model.RightTxt);
            }
            model.Out = txt.ToString();
        }
    }
}
