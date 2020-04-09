namespace Asp.NetCore.EFCore.Models.Migrations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
 

    [Table("SysRoleMenuMapping")]
    public partial class SysRoleMenuMapping
    {
        public int Id { get; set; }

        public int SysRoleId { get; set; }

        public int SysMenuId { get; set; }
    }
}
