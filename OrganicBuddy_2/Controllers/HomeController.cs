using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Microsoft.Win32;
using OrganicBuddy_2.Data;
using OrganicBuddy_2.Models;
using System.Diagnostics;


namespace OrganicBuddy_2.Controllers
{
	public class HomeController : Controller
    { 
        private OBAppDbContext _db;
		
        public HomeController(OBAppDbContext db)
        {
            _db = db;
        }


       
        public  IActionResult Index(string search)
        {
            // Initialize the services list
            var services = new List<Service>
        {
            new Service
            {
                Image = "images/service.png",
                Title = "Free Shipping",
                Tagline = "From all orders over ₹500"
            },
            new Service
            {
                Image = "images/service-02.png",
                Title = "Daily Surprise Offers",
                Tagline = "Save upto 25% off"
            },
            new Service
            {
                Image = "images/service-03.png",
                Title = "Support 24/7",
                Tagline = "Shop with an expert"
            },
            new Service
            {
                Image = "images/service-04.png",
                Title = "Affordable Prices",
                Tagline = "Get Farm Default Price"
            },
            new Service
            {
                Image = "images/service-05.png",
                Title = "Secure Payments",
                Tagline = "100% Protected Payment"
            }
        };
           
            return View(services);
        }

        
        public IActionResult Store()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Blogs()
        {
            return View();
        }

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
        public IActionResult CompareProduct()
        {
            return View();
        }
        public IActionResult Wishlist()
        {
            return View();
        }
        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Refund()
        {
            return View();
        }
        public IActionResult Shipping()
        {
            return View();
        }
        public IActionResult TaC()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            if (ModelState.IsValid)
            {
                var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

                if (user != null)
                {
                    // Authentication successful, redirect to home page
                    return RedirectToAction("Index");
                }
                else
                {
                    // Authentication failed, add model state error
                    ModelState.AddModelError("", "Invalid email or password");
                }
            }

            // If model state is not valid or authentication failed, return to login view
            return View();
        }




        public IActionResult SignUp()
        {
            return View();
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(User user)
        {
            if (ModelState.IsValid)
            {
                // If model state is valid, proceed with saving the user
                _db.Add(user);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            // If model state is not valid, return to the signup page with validation errors
            return View(user);
        }


        public IActionResult ForgotPassword()
        {
            return View();
        }

        public IActionResult SingleBlog()
        {
            return View();
        }

        public IActionResult SingleProduct()
        {
            return View();
        }

        public IActionResult CheckOut()
        {
            return View();
        }




    }
}
