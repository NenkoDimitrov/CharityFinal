using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CharityV2.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Activity> Activitiys { get; set; }
        public DbSet<Category> Categories{ get; set; }
  
        public DbSet<ActivityImages> ActivitiesImages { get; set; }
        public DbSet<ActiveActivity> ActiveActivities { get; set; }
        
    }
}
