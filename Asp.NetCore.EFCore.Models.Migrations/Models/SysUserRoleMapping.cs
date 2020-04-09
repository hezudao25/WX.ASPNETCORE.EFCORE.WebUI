namespace Asp.NetCore.EFCore.Models.Migrations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("SysUserRoleMapping")]
    public partial class SysUserRoleMapping
    {
       //public int Id { get; set; }

        public int SysUserId { get; set; }

        public SysUserInfo SysUserInfo { get; set; }

        public SysRole SysRole { get; set; }

        public int SysRoleId { get; set; }
    }
}
