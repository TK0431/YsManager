using OfficeOpenXml;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace Kebin1.Utils
{
    /// <summary>
    /// Excel操作
    /// </summary>
    public class ExcelUtil : IDisposable
    {

        #region Common

        /// <summary>
        /// Excel
        /// </summary>
        private ExcelPackage _excel;

        /// <summary>
        /// Ctor
        /// </summary>
        public ExcelUtil(string excelName)
        {
            // License
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Excel
            _excel = new ExcelPackage(new FileInfo(excelName));
        }

        /// <summary>
        /// Ctor
        /// </summary>
        public ExcelUtil()
        {
            // License
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Excel
            _excel = new ExcelPackage();
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            if (_excel != null) _excel.Dispose();
        }

        #endregion

        /// <summary>
        /// Load DataTable Data
        /// </summary>
        /// <param name="data"></param>
        public void LoadDataTable(DataTable data)
            => this.GetSheet().Cells["A2"].LoadFromDataTable(data, false, TableStyles.Medium9);

        /// <summary>
        /// Load DataTable Data
        /// </summary>
        /// <param name="list"></param>
        public void LoadDataList<T>(List<T> list)
        {
            DataTable data = new DataTable();
            List<PropertyInfo> properties = typeof(T).GetProperties()
                .Where(x => x.GetCustomAttribute<DisplayAttribute>() != null).ToList()
                .OrderBy(x => x.GetCustomAttribute<DisplayAttribute>().Order).ToList();

            properties.ForEach(p => data.Columns.Add(p.Name));

            foreach (var item in list)
            {
                DataRow row = data.NewRow();
                int i = 0;
                properties.ForEach(p =>
                {
                    row[i++] = p.GetValue(item);
                });
                data.Rows.Add(row);
            }

            this.LoadDataTable(data);
        }

        /// <summary>
        /// Add Sheet
        /// </summary>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public ExcelWorksheet AddSheet(string sheetName)
            => _excel.Workbook.Worksheets.Add(sheetName);

        /// <summary>
        /// Add Sheet
        /// </summary>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public ExcelWorksheet GetSheet(int index = 0)
            => _excel.Workbook.Worksheets[index];

        /// <summary>
        /// Add Sheet
        /// </summary>
        /// <param name="sheetName"></param>
        /// <returns></returns>
        public ExcelWorksheet GetSheet(string sheetName)
            => _excel.Workbook.Worksheets[sheetName];

        /// <summary>
        /// Save
        /// </summary>
        public void Save()
            => _excel.Save();

        /// <summary>
        /// SaveAs
        /// </summary>
        /// <param name="file"></param>
        public void SaveAs(FileInfo file)
            => _excel.SaveAs(file);
    }
}