namespace Asp.NetCore.EFCore.Models.Migrations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
 

    [Table("Company")]
    public partial class Company
    { 
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public DateTime? CreateTime { get; set; }

        public int? CreatorId { get; set; }

        public int? LastModifierId { get; set; }

        public DateTime? LastModifyTime { get; set; }

        public string Description { get; set; }

        //public virtual ICollection<SysUserInfo> SysUsers { get; set; }

       public List<SysUserInfo> SysUsers { get; set; }
    }
}
