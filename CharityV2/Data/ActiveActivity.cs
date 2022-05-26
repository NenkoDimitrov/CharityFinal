using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CharityV2.Data
{
    public class ActiveActivity
    {
        public int Id { set; get; }
        public string UserId { get; set; }
        public User User { get; set; }
        public int ActivitiyId { get; set; }
        public Activity Activitiy { get; set; }

    }
}
