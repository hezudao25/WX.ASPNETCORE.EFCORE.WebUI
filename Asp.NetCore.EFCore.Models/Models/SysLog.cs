namespace Asp.NetCore.EFCore.Models.Models
{
 
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
 

    //[Table("SysLog")]
    public partial class SysLog 
    {
        public int Id { get; set; }

        [Required]
        [StringLength(36)]
        public string UserName { get; set; }

        [Required]
        [StringLength(1000)]
        public string Introduction { get; set; }

        [StringLength(4000)]
        public string Detail { get; set; }

        public byte LogType { get; set; }

      

        public int CreatorId { get; set; }


        public int? LastModifierId { get; set; }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? LastModifyTime { get; set; }
         
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    } 
}
