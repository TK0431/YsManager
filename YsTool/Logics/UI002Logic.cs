using FrameWork.Models;
using FrameWork.Models.DB;
using Kebin1.Utils;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Text;
using YsTool.ViewModels;

namespace YsTool.Logics
{
    public class UI002Logic: BaseLogic
    {
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

            using (EFCoreDbContext db = new EFCoreDbContext())
            {
                db.TB_User.AddRange(addList);
                db.SaveChanges();
            }
        }
    }
}
