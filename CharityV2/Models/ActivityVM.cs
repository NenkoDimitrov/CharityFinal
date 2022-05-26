using CharityV2.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CharityV2.Models
{
    public class ActivityVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public List<SelectList> User { get; set; }
        public string EmployeeId { get; set; }
        public List<SelectList> Employee { get; set; }
        public int CategoryId { get; set; }
        public List<SelectList> Category { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime RegistrationTime { get; set; }
        public string Photo { get; set; }
        public int CountInterest { get; set; }
        public int CountParticipants { get; set; }
        public StatusType Status { get; set; }

        [Required(ErrorMessage = "Избери снимка от компютъра си...")]
        public List<IFormFile> ImagePath { get; set; }
    }
}
