namespace Asp.NetCore.EFCore.Models.Migrations.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    [Table("SysUserInfoDetail")] 
    public partial class SysUserInfoDetail
    {
        [Key]
        public int Id { get; set; }

        public int SysUserInfoDetailId { get; set; }

        public string  Description { get; set; }

        public SysUserInfo SysUserInfo { get; set; }
    }
}
