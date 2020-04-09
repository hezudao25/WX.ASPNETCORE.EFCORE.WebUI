namespace Asp.NetCore.EFCore.Models.Migrations.Models
{
    using Asp.NetCore.EFCore.Models.Migrations.Extend;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
 

    //[Table("SysLog")]
    public partial class SysLog: IBaseEntity
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
        /// �޸�ʱ��
        /// </summary>
        public DateTime? LastModifyTime { get; set; }
         
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime CreateTime { get; set; }
    } 
}
