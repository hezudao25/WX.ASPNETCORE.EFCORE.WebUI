using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCore.EFCore.Models.Extend
{
    /// <summary>
    /// 分页 通用数据传输对象
    /// </summary>
    public class PageInfo<T>
    {
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// 摘要:    --要显示的页码
        /// </summary>
        public int PageCurrent { get; set; }
        /// <summary>
        /// 摘要: --每页的大小(记录数)
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 摘要:  分页数据集
        /// </summary>
        public IEnumerable<T> Result { get; set; }
        /// <summary>
        /// 摘要: 总记录数
        /// </summary>
        public int RowsCount { get; set; }
    }
}
