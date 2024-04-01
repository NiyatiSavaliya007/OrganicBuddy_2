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
            var cartItems = _db.Products.ToList();
            return View(cartItems);
        }
        [HttpPost]
        public async Task<IActionResult> Index(int id)
        {
            var product = await _db.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var cartItem = new Pro
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,

            };

            // Check if the entity is already tracked, and if not, add it
            var existingCartItem = await _db.Products.FindAsync(cartItem.Id);
            if (existingCartItem == null)
            {
                _db.Products.Add(cartItem);
            }
            else
            {
                // Update the existing tracked entity with the new values
                _db.Entry(existingCartItem).CurrentValues.SetValues(cartItem);
            }

            await _db.SaveChangesAsync();

            return RedirectToAction("ComparePage");
        }



        public IActionResult Store()
        {
            var cartItems = _db.Products.ToList();
            return View(cartItems);
        }
        [HttpPost]
        public async Task<IActionResult> Store(int id)
        {
            var product = await _db.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var cartItem = new Pro
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,

            };

            // Check if the entity is already tracked, and if not, add it
            var existingCartItem = await _db.Products.FindAsync(cartItem.Id);
            if (existingCartItem == null)
            {
                _db.Products.Add(cartItem);
            }
            else
            {
                // Update the existing tracked entity with the new values
                _db.Entry(existingCartItem).CurrentValues.SetValues(cartItem);
            }

            await _db.SaveChangesAsync();

            return RedirectToAction("ComparePage");
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
            var cartItems = _db.Products.ToList();
            return View(cartItems);
        }
        [HttpPost]
        public async Task<IActionResult> CompareProduct(int id)
        {
            var product = await _db.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var cartItem = new Pro
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,

            };

            // Check if the entity is already tracked, and if not, add it
            var existingCartItem = await _db.Products.FindAsync(cartItem.Id);
            if (existingCartItem == null)
            {
                _db.Products.Add(cartItem);
            }
            else
            {
                // Update the existing tracked entity with the new values
                _db.Entry(existingCartItem).CurrentValues.SetValues(cartItem);
            }

            await _db.SaveChangesAsync();

            return RedirectToAction("ComparePage");
        }
        public IActionResult Wishlist()
        {
            var cartItems = _db.Products.ToList();
            return View(cartItems);
        }
        [HttpPost]
        public async Task<IActionResult> WishList(int id)
        {
            var product = await _db.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var cartItem = new Pro
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,

            };

            // Check if the entity is already tracked, and if not, add it
            var existingCartItem = await _db.Products.FindAsync(cartItem.Id);
            if (existingCartItem == null)
            {
                _db.Products.Add(cartItem);
            }
            else
            {
                // Update the existing tracked entity with the new values
                _db.Entry(existingCartItem).CurrentValues.SetValues(cartItem);
            }

            await _db.SaveChangesAsync();

            return RedirectToAction("ComparePage");
        }
        public IActionResult Cart()
        {
            var cartItems = _db.Products.ToList();
            return View(cartItems);
            
        }
        [HttpPost]
        public async Task<IActionResult> Cart(int id)
        {
            var product = await _db.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var cartItem = new Pro
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,

            };

            // Check if the entity is already tracked, and if not, add it
            var existingCartItem = await _db.Products.FindAsync(cartItem.Id);
            if (existingCartItem == null)
            {
                _db.Products.Add(cartItem);
            }
            else
            {
                // Update the existing tracked entity with the new values
                _db.Entry(existingCartItem).CurrentValues.SetValues(cartItem);
            }

            await _db.SaveChangesAsync();

            return RedirectToAction("CartPage");
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

        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                // Handle empty search query
                // For example, redirect to the homepage
                return RedirectToAction("Index");
            }

            // Query the database for products matching the search query
            var matchingProducts = await _db.Products
                .Where(p => EF.Functions.Like(p.Name, $"%{query}%"))
                .ToListAsync();

            // Pass the search results to the view
            return View(matchingProducts);
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
