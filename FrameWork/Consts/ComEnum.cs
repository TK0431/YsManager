using FrameWork.Models;
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
    }

    /// <summary>
    /// 权限
    /// </summary>
    public enum EnumLevel
    {
        [Value("0"), Description("")]
        LEVEL0_0,
        [Value("1"), Description("组员")]
        LEVEL0_1,
        [Value("2"), Description("组长")]
        LEVEL0_2,
        [Value("3"), Description("项目负责人")]
        LEVEL0_3,
        [Value("4"), Description("项目经理")]
        LEVEL0_4,
        [Value("9"), Description("超级")]
        LEVEL0_9,
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
