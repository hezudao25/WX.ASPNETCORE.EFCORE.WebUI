using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.EFCore.Models.Migrations.Extend
{
    public interface IBaseEntity
    {
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
