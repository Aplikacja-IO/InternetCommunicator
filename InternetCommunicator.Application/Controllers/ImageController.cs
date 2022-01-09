using System.IO;
using System.Web;
using InternetMessengerApp.Models;
using InternetMessengerApp.Models.Helpers;
using InternetMessengerApp.Models.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using InternetCommunicator.Domain.Models;

namespace Uploadimage.Controllers
{
    public class ImageController : Controller
    {
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Image imageModel)
        {
            string fileName = Path.GetFileNameWithoutExtension(imageModel.ImageFile.FileName);
            string extension = Path.GetExtension(imageModel.ImageFile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            imageModel.ImageUrl = "~/Image/" + fileName;
            fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            imageModel.ImageFile.SaveAs(fileName);
            using (DbModels db = new DbModels())
            {
                db.Images.Add(imageModel);
                db.SaveChanges();
            }
            ModelState.Clear();
            return View();
        }

        [HttpGet]
        public ActionResult View(int id)
        {
            Image imageModel = new Image();

            using (DbModels db= new DbModels())
            {
                imageModel = db.Images.Where(x => x.ImageID == id).FirstOrDefault();
            }

            return View(imageModel);
        }
	}
}
public partial class Image
{
    public int ComponentId { get; set; }
    public string ImageUrl { get; set; }

    public virtual Component Component { get; set; }
}
}
