﻿using FrameWork.Models;
using FrameWork.Models.DB;
using FrameWork.Utility;
using Kebin1.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace FrameWork.Consts
{
    /// <summary>
    /// 消息
    /// </summary>
    public enum MessageCode
    {
        [Description("")]
        KEB0000W,
        [Description("")]
        KEB0001I,
        [Description("")]
        KEB0002I,
        [Description("")]
        KEB0003I,
        [Description("")]
        KEB0004I,
    }

    /// <summary>
    /// 权限
    /// </summary>
    public enum EnumType
    {
        [Value("01"), Description("权限")]
        Type_01,
        [Value("02"), Description("开发语言")]
        Type_02,
    }

    /// <summary>
    /// 权限
    /// </summary>
    public enum EnumLevel
    {
        [Value("0"), Description("")]
        LEVEL_0,
        [Value("1"), Description("组员")]
        LEVEL_1,
        [Value("2"), Description("组长")]
        LEVEL_2,
        [Value("3"), Description("项目负责人")]
        LEVEL_3,
        [Value("4"), Description("项目经理")]
        LEVEL_4,
        [Value("9"), Description("超级")]
        LEVEL_9,
    }

    /// <summary>
    /// 开发语言
    /// </summary>
    public enum EnumDevLang
    {
        [Value("0"), Description("")]
        ALL,
        [Value("1"), Description("C#")]
        CSHUP,
        [Value("2"), Description("JAVA")]
        JAVA,
        [Value("3"), Description("Python")]
        PYTHON,
        [Value("4"), Description("C")]
        C,
        [Value("5"), Description("C++")]
        CPLUS,
    }

    /// <summary>
    /// 将枚举更新到数据库
    /// </summary>
    public static class UpdateEnum
    {
        public static void Update()
        {
            using (EntityDao db = new EntityDao())
            {
                db.DeleteAll("delete from tb_type");

                AddDatas(db, typeof(EnumLevel), EnumType.Type_01.GetValue());
            }
        }

        private static void AddDatas(EntityDao db,Type type, string typeValue)
        {
            List<EnumItem> list = type.GetList();
            List<TB_Type> datas = new List<TB_Type>();

            list.ForEach(x => datas.Add(new TB_Type() { 
                Type = typeValue,
                Value = x.Value,
                Name = x.Description,
                InserterCd = "CD0000",
                InserteTime = db.DbConectTime,
                UpdaterCd = "CD0000",
                UpdateTime = db.DbConectTime,
            }));

            db.Add(datas);
        }
    }
}
