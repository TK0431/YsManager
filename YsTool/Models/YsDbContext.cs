using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using YsTool.Models.DB;

namespace YsTool.Models
{
    public class YsDbContext: DbContext
    {
        public YsDbContext() : base("name=KebDbContext")
        {
            Database.SetInitializer<YsDbContext>(null);
            Database.Log = x =>
            {
                //Log4.WriteInfo(x.LastIndexOf("\r\n") > 0 ? x.Remove(x.LastIndexOf("\r\n"), 2) : x);
            };
        }

        //public virtual DbSet<ank_m_intermediate_end_reason> ank_m_intermediate_end_reason { get; set; }
        //public virtual DbSet<ank_m_project_end_bid_result_kubun> ank_m_project_end_bid_result_kubun { get; set; }
        //public virtual DbSet<ank_m_spread_json_data> ank_m_spread_json_data { get; set; }
        //public virtual DbSet<to_project_all_recieve_info_recv0205> to_project_all_recieve_info_recv0205 { get; set; }
        //public virtual DbSet<to_purchase_specification> to_purchase_specification { get; set; }
        //public virtual DbSet<to_sales> to_sales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties().Where(p => p.Name == "UpdateTime").Configure(p => p.IsConcurrencyToken());

            //modelBuilder.Configurations.Add(new Map_ank_m_spread_json_data());
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes().ToList()
                .Where(type => !string.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == typeof(BaseEntityMap<>));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
        }
    }
}
