namespace Asp.NetCore.EFCore.Models.Migrations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("SysRole")]
    public partial class SysRole
    {
        public int Id { get; set; }

        [Required]
        [StringLength(36)]
        //[Column("Text")]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }
         
        public byte Status { get; set; }

        public DateTime CreateTime { get; set; }

        public int CreateId { get; set; }

        public DateTime? LastModifyTime { get; set; }

        public int? LastModifierId { get; set; }

        public List<SysUserRoleMapping> SysUserRoleMapping { get; set; }
    }
}
