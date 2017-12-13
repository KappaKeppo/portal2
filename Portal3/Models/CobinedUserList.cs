using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Portal3.Models
{
    public class CobinedUserList
    {
        public List<User1C> list1C { get; set; }
        public List<UserCRM> listCRM { get; set; }
        public List<UserSpr> listSpr { get; set; }
    }
}