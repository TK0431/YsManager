using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

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
