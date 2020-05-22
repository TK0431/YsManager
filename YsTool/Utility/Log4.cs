﻿using log4net;
using System;

namespace Kebin1.Utils
{
    public class Log4
    {
        /// <summary>
        /// 異常
        /// </summary>
        /// <param name="e"></param>
        public static void WriteError(object text, Exception e)
        {
            ILog log = LogManager.GetLogger("異常ログ", text.GetType());
            log.Error(text, e);
        }

        /// <summary>
        /// デバッグ
        /// </summary>
        /// <param name="text"></param>
        public static void WriteDebug(object text)
        {
            ILog log = LogManager.GetLogger("デバッグログ", text.GetType());
            log.Debug(text);
        }

        /// <summary>
        /// 输出程序运行信息
        /// </summary>
        /// <param name="text"></param>
        public static void WarnInfo(object text)
        {
            ILog log = LogManager.GetLogger("警告ログ", text.GetType());
            log.Warn(text);
        }

        /// <summary>
        /// 输出程序运行信息
        /// </summary>
        /// <param name="text"></param>
        public static void WriteInfo(object text)
        {
            ILog log = LogManager.GetLogger("正常ログ", text.GetType());
            log.Info(text);
        }
    }
}