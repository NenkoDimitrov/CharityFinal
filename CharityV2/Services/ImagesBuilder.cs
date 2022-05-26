using CharityV2.Data;
using CharityV2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using System;
using System.IO;
using System.Threading.Tasks;

namespace CharityV2.Services
{
    public class ImagesBuilder
    {
        private readonly ApplicationDbContext _context;
       // private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _hostEnvironment;
        private string wwwroot;

        public ImagesBuilder (ApplicationDbContext context, IWebHostEnvironment hostEnvironment) 
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
           // _userManager = userManager;
            wwwroot = $"{this._hostEnvironment.WebRootPath}";
        }
        
        ///
        public async Task CreateImages(ActivityVM model, string currentUser)
        {
            
            Activity modelToDb = new Activity()
            {
                Name = model.Name,
                CategoryId = model.CategoryId,
                CountInterest = model.CountInterest,
                CountParticipants = model.CountParticipants,
                EndDate = model.EndDate,
                StartDate = model.StartDate,
                Place = model.Place,
                Status = StatusType.Awaiting,
                Description = model.Description,
                RegistrationTime = DateTime.Now,
                UserId = currentUser
            };
            await _context.Activitiys.AddAsync(modelToDb);
            await this._context.SaveChangesAsync();

            //създаваме папката images, ако не съществува
            Directory.CreateDirectory($"{wwwroot}/Images/");
            var imagePath = Path.Combine(wwwroot, "Images");
            string uniqueFileName = null;
            if (model.ImagePath.Count > 0)
            {
                for (int i = 0; i < model.ImagePath.Count; i++)
                {
                    ActivityImages dbImage = new ActivityImages()
                    {
                        ActivitiyId = modelToDb.Id,
                        Activitiy = modelToDb
                    };//id се създава автоматично при създаване на обект
                    if (model.ImagePath[i] != null)
                    {
                        uniqueFileName = dbImage.Id + "_" + model.ImagePath[i].FileName;
                        string filePath = Path.Combine(imagePath, uniqueFileName);
                        using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await model.ImagePath[i].CopyToAsync(fileStream);
                        }

                        dbImage.ImagePath = uniqueFileName;
                        await _context.ActivitiesImages.AddAsync(dbImage);
                        await this._context.SaveChangesAsync();
                    }
                }
            }
        }
    }
}
