using FrameWork.Consts;
using FrameWork.Models;
using Kebin1.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using YsTool.Utility;

namespace YsTool
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// 语言
        /// </summary>
        public static string Language { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            //DbContextOptions contextOptions = new DbContextOptionsBuilder().UseMySQL("Server=127.0.0.1;database=ysdb;uid=root;password=123456").Options;

            //IServiceCollection services = new ServiceCollection().AddSingleton(contextOptions).AddScoped<EFCoreDbContext>();

            //services.BuildServiceProvider();

            // UpdateEnum.Update();

            Language = string.Empty;
            try
            {
                Language = YsTool.Properties.Resources.Language.Trim();
            }
            catch (Exception)
            {
            }
            //Language = string.IsNullOrEmpty(Language) ? "en-us" : Language;
            Language = "en-us";

            UpdateLanguage();
        }

        /// <summary>
        /// 更换语言包
        /// </summary>
        public static void UpdateLanguage()
        {
            List<ResourceDictionary> dictionaryList = new List<ResourceDictionary>();
            foreach (ResourceDictionary dictionary in Application.Current.Resources.MergedDictionaries)
            {
                dictionaryList.Add(dictionary);
            }
            string requestedLanguage = $@"Styles/{Language}.xaml";
            ResourceDictionary resourceDictionary = dictionaryList.FirstOrDefault(d => d.Source.OriginalString.Equals(requestedLanguage));
            if (resourceDictionary == null)
            {
                requestedLanguage = @"Styles/en-us.xaml";
                resourceDictionary = dictionaryList.FirstOrDefault(d => d.Source.OriginalString.Equals(requestedLanguage));
            }
            if (resourceDictionary != null)
            {
                Application.Current.Resources.MergedDictionaries.Remove(resourceDictionary);
                Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
            }
        }

    }
}
