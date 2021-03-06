using System;
using System.ComponentModel.DataAnnotations;

namespace CharityV2.Data
{
    public class ActivityImages
    {
        public ActivityImages()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        [Key]
        public string Id { get; set; }
        [Required]
        public string ImagePath { get; set; }
     
        [Required]
        public int ActivitiyId { get; set; }
        public Activity Activitiy { get; set; }
    }
}
