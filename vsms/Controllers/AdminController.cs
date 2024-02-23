using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using vsms.Data;
using vsms.Models;

namespace vsms.Controllers
{
    public class AdminController : Controller
    {

        private readonly eprojectContext DB;

        public AdminController(eprojectContext DB)
        {
            this.DB = DB;
        }

  

        public IActionResult Index()
        {
            return View(DB.Users.ToList());
        }

        public IActionResult AddVehicle()
        {
            return View();
        }

        public IActionResult ShowVehicle()
        {
            return View(DB.NewVehicles.ToList());
           
        }

        public IActionResult EditVehicle(int? Id)
        {
            var Data = DB.NewVehicles.Find(Id);
            if (Data == null)
            {
                ViewData["Error"] = "Id does not Exists";
                return RedirectToAction(nameof(ShowVehicle));
            }

            return View(Data);
        }

        public IActionResult Update(NewVehicle NV, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {

                Guid r = Guid.NewGuid();
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var extensioon=file.ContentType.ToLower();
                var exten_pricese = extensioon.Substring(6);
                var unique_name = fileName + r + "." + exten_pricese;
                string imagesFolder = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/images");
                string filePath = Path.Combine(imagesFolder, unique_name);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                var dbAdress = Path.Combine("images", unique_name);
                NV.CompanyVehicleImage = dbAdress;
                DB.Update(NV);
                DB.SaveChanges();
                TempData["msg"] = "Data Updated!!";

                return RedirectToAction(nameof(ShowVehicle));
            }

            return View();

        }

        public IActionResult DeleteVehicle(int? Id)
        {
            var data = DB.NewVehicles.FirstOrDefault(y => y.VehicleId == Id);
            DB.Remove(data);
            DB.SaveChanges();
            TempData["msg"] = "Data Deleted!!";
            return RedirectToAction(nameof(ShowVehicle));
        }


        public IActionResult CreateVehicle( NewVehicle NV, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filename = Path.GetFileName(file.FileName);
                string folderPath = Path.Combine("wwwroot/images", filename);
                var dbpath = Path.Combine("images", filename);
                using (var stream = new FileStream(folderPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                NV.CompanyVehicleImage = dbpath;
                DB.Add(NV);
                DB.SaveChanges();
                return Redirect(nameof(Index));


            }
            return View("AddCompanyVehicle");
        }

        public IActionResult AddCompanyVehicle()
        {
            return View();
        }
        public IActionResult Orders()
        {
            return View(DB.TblCheckouts.ToList());

        }
        public IActionResult OrderItems()
        {
            ViewBag.orders = DB.CustomerOrderItems.Include(x => x.Order).Include(y=>y.Vehicle).ToList();
            return View();
        }
        public IActionResult Addrole()
        {
            return View();
        }
        public IActionResult addrole2(Role R)
        {
            DB.Add(R);
            DB.SaveChanges();

            return RedirectToAction(nameof(showrole));
        }
        public IActionResult showrole()
        {
            return View(DB.Roles.ToList());
        }
        public IActionResult editrole(int? Id)
        {
            var dataa = DB.Roles.Find(Id);
            if (dataa == null)
            {
                ViewData["error"] = "Id does not exists";

                return RedirectToAction(nameof(editrole));
            }
            return View(dataa);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult editrole2(Role r)
        {
            DB.Update(r);
            DB.SaveChanges();
            TempData["msg"] = "Data updated!!";
            TempData.Keep("msg");
            return RedirectToAction(nameof(showrole));

        }
        public IActionResult deleterole(int? Id)
        {
            var data = DB.Roles.FirstOrDefault(y => y.Rid == Id);
            DB.Remove(data);
            DB.SaveChanges();
            TempData["msg"] = "Data deleted!!";
            TempData.Keep("msg");
            return RedirectToAction(nameof(showrole));
        }
        public IActionResult adduser2(User U, IFormFile file)
        {
           
                if (file != null && file.Length > 0)
                {
                    var filename = Path.GetFileName(file.FileName);
                    string folderPath = Path.Combine("wwwroot/images", filename);
                    var dbpath = Path.Combine("images", filename);
                    using (var stream = new FileStream(folderPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    U.UserImage = dbpath;
                    DB.Add(U);
                    DB.SaveChanges();
                    return Redirect(nameof(showuser));


                }
                return View("Login");
            
        }
        public IActionResult adduser()
        {
           
            return View();
        }
        public IActionResult showuser()
        {
            return View(DB.Users.ToList());
        }
        public IActionResult edituser(int? Id)
        {
            var dataa = DB.Users.Find(Id);
            if (dataa == null)
            {
                ViewData["error"] = "Id does not exists";

                return RedirectToAction(nameof(edituser));
            }
            return View(dataa);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult edituser2(User rr, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {

                Guid r = Guid.NewGuid();
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var extensioon = file.ContentType.ToLower();
                var exten_pricese = extensioon.Substring(6);
                var unique_name = fileName + r + "." + exten_pricese;
                string imagesFolder = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/images");
                string filePath = Path.Combine(imagesFolder, unique_name);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                var dbAdress = Path.Combine("images", unique_name);
                rr.UserImage = dbAdress;

               
                DB.Update(rr);
                DB.SaveChanges();
                TempData["msg"] = "Data updated!!";
                TempData.Keep("msg");

                return RedirectToAction(nameof(showuser));
            }


            return View();
        }
        public IActionResult deleteuser(int? Id)
        {
            var data = DB.Users.FirstOrDefault(y => y.UserId == Id);
            DB.Remove(data);
            DB.SaveChanges();
            TempData["msg"] = "Data deleted!!";
            TempData.Keep("msg");
            return RedirectToAction(nameof(showuser));
        }
        public IActionResult CreateCompanyVehicle(CompanyVehicle CV, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filename = Path.GetFileName(file.FileName);
                string folderPath = Path.Combine("wwwroot/images", filename);
                var dbpath = Path.Combine("images", filename);
                using (var stream = new FileStream(folderPath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                CV.CompanyVehicleImage = dbpath;
                DB.Add(CV);
                DB.SaveChanges();
                return Redirect(nameof(ShowCompanyVehicles));


            }
            return View("AddVehicle");
        }




        public IActionResult ShowCompanyVehicles()
        {
            return View(DB.CompanyVehicles.ToList());

        }

        public IActionResult CompanyPurchaseVehicle(int? Id)
        {
            var Data = DB.CompanyVehicles.Find(Id);
            var model = new CompanyVehicle
            {
                // Populate other properties...
                CompanyVehicleImage = Data.CompanyVehicleImage // Set the image path
            };


            return View(Data);

        }


        public IActionResult Price(NewVehicle CV, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {

                Guid r = Guid.NewGuid();
                var fileName = Path.GetFileNameWithoutExtension(file.FileName);
                var extensioon = file.ContentType.ToLower();
                var exten_pricese = extensioon.Substring(6);
                var unique_name = fileName + r + "." + exten_pricese;
                string imagesFolder = Path.Combine(HttpContext.Request.PathBase.Value, "wwwroot/images");
                string filePath = Path.Combine(imagesFolder, unique_name);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                var dbAdress = Path.Combine("images", unique_name);
                CV.CompanyVehicleImage = dbAdress;
              
                DB.Add(CV);
                DB.SaveChanges();
                TempData["msg"] = "Data Updated!!";

                return RedirectToAction(nameof(ShowVehicle));
            }

            return View();

        }


    }
}
