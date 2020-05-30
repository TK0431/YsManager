using FrameWork.Models;
using FrameWork.Models.DB;
using FrameWork.Utility;
using Kebin1.Utils;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using YsTool.ViewModels;

namespace YsTool.Logics
{
    public class UI002Logic : BaseLogic
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void GetUsers(UI002ViewModel model)
        {
            using (EntityDao db = new EntityDao())
            {
                model.Items = new ObservableCollection<UI002Item>(db.FindAll< UI002Item>("select Cd,Name,GroupId as 'Group',IP,'0' as 'Delete' from tb_user"));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void FileReplace(UI002ViewModel model)
        {
            string file = FileDialog();

            if (file == null) return;

            using ExcelUtil excel = new ExcelUtil(file);

            ExcelWorksheet sheet = excel.GetSheet();

            List<TB_User> addList = new List<TB_User>();
            for (int i = 2; !string.IsNullOrWhiteSpace(sheet.Cells[i, 1].Text); i++)
            {
                TB_User tb = new TB_User()
                {
                    CD = sheet.Cells[i, 1].Text,
                    Name = sheet.Cells[i, 2].Text,
                    Password = sheet.Cells[i, 3].Text,
                    IP = sheet.Cells[i, 4].Text,
                    GroupId = sheet.Cells[i, 5].Text,
                    Level = 0,
                    InserterCd = "CD001",
                    InserteTime = DateTime.Now,
                    UpdaterCd = "CD001",
                    UpdateTime = DateTime.Now,
                };
                addList.Add(tb);
            }

            using (EntityDao db = new EntityDao())
            {
                db.Add(addList);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        public void GetIP(UI002ViewModel model)
        {
            // 
            IPAddress address = ComUtility.GetLocalIPV4();

            // 
            if (address != null)
            {
                model.IP1 = address.GetAddressBytes()[0];
                model.IP2 = address.GetAddressBytes()[1];
                model.IP3 = address.GetAddressBytes()[2];
                model.IP4 = address.GetAddressBytes()[3];
            }
        }
    }
}
