using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Asp.NetCore.EFCore.Models.Models
{
    public class UserInfo
    {
        [Key]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public int UserAge { get; set; }
         
        public string Description { get; set; }
    }
}
