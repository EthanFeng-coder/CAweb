using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace CA.Pages
{
    public class AccountModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string UserName { get; set; }

        [BindProperty]
        public List<CartItem> CartItems { get; set; }

        public void OnGet()
        {
            // Load the user's shopping cart items from the database or session
            CartItems = LoadCartItems(UserName);
        }

        public IActionResult OnPostUpdateCart()
        {
            // Save the updated shopping cart items to the database or session
            SaveCartItems(UserName, CartItems);
            // Redirect back to the account page
            return RedirectToPage(new { UserName });
        }

        public IActionResult OnPostCheckout()
        {
            // Save the shopping cart items to the database and process the payment
            SaveCartItems(UserName, CartItems);
            ProcessPayment(CartItems);
            // Clear the shopping cart items and redirect to the account page
            CartItems.Clear();
            SaveCartItems(UserName, CartItems);
            return RedirectToPage(new { UserName });
        }

        private List<CartItem> LoadCartItems(string userName)
        {
            var cartItems = new List<CartItem>();

            // Add a subscription item to the cart
            var subscriptionItem = new CartItem
            {
                
                ProductName = "Subscription",
                Price = 9.99m,
                Quantity = 1,
                ImageUrl = "https://img.freepik.com/free-vector/neon-style-coming-soon-glowing-background-design_1017-25516.jpg",
                Id = "sub-1",
                api="http://192.168.0.144:443/api/Users/UpdateSubscription"
            };
            cartItems.Add(subscriptionItem);
             var PayIssues = new CartItem
            {
                
                ProductName = "PayIssues",
                Price = 9.99m,
                Quantity = 1,
                ImageUrl = "https://img.freepik.com/free-vector/neon-style-coming-soon-glowing-background-design_1017-25516.jpg",
                Id = "sub-2"
            };
            cartItems.Add(PayIssues);

            return cartItems;
        }

        private void SaveCartItems(string userName, List<CartItem> cartItems)
        {
            // Save the shopping cart items to the database or session
        }

        private void ProcessPayment(List<CartItem> cartItems)
        {
            // Process the payment using a payment gateway or other service
        }
    }

    public class CartItem
    {
        
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; }
        public string Id { get; set; }
        public string api {get;set;}
    }
}
