using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CharityV2.Data
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public  Category Category { get;set; }        
        public string Description { get; set; }
        public string Place { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RegistrationTime { get; set; }
        public ICollection<ActivityImages> ActivityImages { get; set; }
        public int CountInterest { get; set; }
        public int CountParticipants { get; set; }
        public StatusType Status { get; set; }
        public ICollection<ActiveActivity> ActiveActivities { get; set; }
    }
}
