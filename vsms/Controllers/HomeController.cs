using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using vsms.Data;
using vsms.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace vsms.Controllers
{
    public class HomeController : Controller
    {
        private readonly eprojectContext DB;
        public List<NewVehicle> getVecData = new List<NewVehicle>();
        public HomeController(eprojectContext DB)
        {
            this.DB = DB;
        }
        //[Authorize(Roles = "User")]
        public IActionResult Index()
        {
            return View(DB.NewVehicles.ToList());
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        public IActionResult AddCart()
        {
            string getVecID = Request.Form["txtVNo"].ToString();
            getVecData = DB.NewVehicles.Where(v => v.VehicleId == Int32.Parse(getVecID)).ToList();
            return View(getVecData);
            //return Content("Done" + getVecID);
        }
        [HttpGet]
        public IActionResult AddCart(string msg)
        {
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult checkout()
        {
            string VNo = Request.Form["tvNo"].ToString();
            string userIDD = User.FindFirst(ClaimTypes.NameIdentifier.ToString())?.Value;
            TblCheckout Obj = new TblCheckout()
            {
                VNo = VNo,
                OrderDate = DateTime.Now.ToString("dd-MMM-yyyy"),
                UserId = userIDD
            };
            DB.TblCheckouts.Add(Obj);
            DB.SaveChanges();
            TempData["msg"] = " Order Succussfully Placed ";
            return RedirectToAction("Index", "Home");
        }
        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
        [Authorize(Roles = "User")]

      

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Car()
        {
            return View(DB.NewVehicles.ToList());
        }

      

        public IActionResult News()
        {
            return View();
        }

        public IActionResult Portfolio()
        {
            return View(DB.NewVehicles.ToList());
        }

        public IActionResult Login(string returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        public IActionResult Log(User U, string ReturnUrl)
        {
            var res = DB.Users.FirstOrDefault(x => x.UserEmail == U.UserEmail && x.UserPassword == U.UserPassword);
            ClaimsIdentity identity = null;
            bool isAuthenticate = false;
            if (res != null)
            {

                if (res.Roles == 1)
                {
                    identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, res.UserName),
                     new Claim(ClaimTypes.NameIdentifier, res.UserId.ToString()),
                    new Claim(ClaimTypes.Role,"Admin")

                }, CookieAuthenticationDefaults.AuthenticationScheme);
                    isAuthenticate = true;
                }
                else
                {
                    identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, res.UserName),
                    new Claim(ClaimTypes.NameIdentifier, res.UserId.ToString()),
                    new Claim(ClaimTypes.Role,"User")

                }, CookieAuthenticationDefaults.AuthenticationScheme);
                    isAuthenticate = true;
                }

                if (isAuthenticate)
                {
                    var principal = new ClaimsPrincipal(identity);
                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                   
                        if (res.Roles == 2)
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                    
                  
                }


            }

            ViewBag.dataa = "Invalid Credentials";
            return View("Login");

        }
        public IActionResult Signup()
        {
            return View();
        }




        public IActionResult CreateUser(User U, IFormFile file)
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
                return Redirect(nameof(Index));


            }
            return View("Login");
        }
        [Authorize(Roles = "User")]



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}