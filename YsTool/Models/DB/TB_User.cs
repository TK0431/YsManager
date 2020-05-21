using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace YsTool.Models.DB
{
    /// <summary>
    /// User Table
    /// </summary>
    [Table("tb_user"), Serializable]
    public class TB_User : TBBase
    {
        [Display(Description = "ID", Order = 1), Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ID { get; set; }

        [Display(Description = "用户名", Order = 2),Required,StringLength(10)]
        public string Name { get; set; }

        public string Password { get; set; }

        public string IP { get; set; }

        public string GroupId { get; set; }

        public int Level { get; set; }
    }

    public class Map_ank_m_spread_json_data : BaseEntityMap<TB_User>
    {
        public Map_ank_m_spread_json_data() : base()
        {
            // Index(ank_t_bid_plan_information_company_cd_identification_no_per_key)
            //Property(t => t.company_cd).HasColumnAnnotation("Index", new IndexAttribute("ank_t_bid_plan_information_company_cd_identification_no_per_key", 0) { IsUnique = true });
            //Property(t => t.identification_no).HasColumnAnnotation("Index", new IndexAttribute("ank_t_bid_plan_information_company_cd_identification_no_per_key", 1) { IsUnique = true });
            //Property(t => t.period_no).HasColumnAnnotation("Index", new IndexAttribute("ank_t_bid_plan_information_company_cd_identification_no_per_key", 2) { IsUnique = true });
            //Property(t => t.project_seq).HasColumnAnnotation("Index", new IndexAttribute("ank_t_bid_plan_information_company_cd_identification_no_per_key", 3) { IsUnique = true });
            //Property(t => t.branch_no).HasColumnAnnotation("Index", new IndexAttribute("ank_t_bid_plan_information_company_cd_identification_no_per_key", 4) { IsUnique = true });
            //Property(t => t.prcs_kubun_cd).HasColumnAnnotation("Index", new IndexAttribute("ank_t_bid_plan_information_company_cd_identification_no_per_key", 5) { IsUnique = true });
        }
    }
}
