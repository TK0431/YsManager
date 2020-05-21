using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace YsTool.Models.DB
{
    public class TBBase
    {
        public bool DelFlg { get; set; }

        public string CreateId { get; set; }

        public DateTime? CreateTime { get; set; }

        public string UpdateId { get; set; }

        public DateTime? UpdateTime { get; set; }
    }

    public class BaseEntityMap<T> : EntityTypeConfiguration<T> where T : TBBase
    {
        public BaseEntityMap()
        {
            // 排他属性
            Property(p => p.UpdateTime).IsConcurrencyToken();

            //var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
            //    .Where(type => !String.IsNullOrEmpty(type.Namespace))
            //    .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(BaseEntityMap<>));

            //foreach (var type in typesToRegister)
            //{
            //    dynamic configurationInstance = Activator.CreateInstance(type);
            //    modelBuilder.Configurations.Add(configurationInstance);
            //}
        }
    }
}
