namespace Asp.NetCore.EFCore.Models.Models
{
 
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    //[Table("SysUser", Schema = "Zhaxoxi")] //对应数据库里表名称
    public partial class SysUserInfo 
    {
        public int Id { get; set; }

        [Column("UserName")]
        [Required]
        //[StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(64)]
        public string Password { get; set; }

        public byte Status { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(20)]
        public string Mobile { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        public long? QQ { get; set; }

        [StringLength(50)]
        public string WeChat { get; set; }

        public byte? Sex { get; set; }

        public DateTime? LastLoginTime { get; set; }

        public DateTime CreateTime { get; set; }

        public int CreateId { get; set; }

        public DateTime? LastModifyTime { get; set; }

        //public int? LastModifyId { get; set; }

        public int CompanyId { get; set; }

        public SysUserInfoDetail SysUserInfoDetail { get; set; }

        public virtual Company Company { get; set; }
         
         public List<SysUserRoleMapping> SysUserRoleMapping { get; set; }
    }
}
