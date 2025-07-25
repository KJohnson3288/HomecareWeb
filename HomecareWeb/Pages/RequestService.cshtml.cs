using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HomecareWeb.Models;
using HomecareWeb.Data;
using Microsoft.AspNetCore.Authorization;

namespace HomecareWeb.Pages
{
    [Authorize]
    public class RequestServiceModel : PageModel
    {
        private readonly AppDbContext _context;

        [BindProperty]
        public ServiceRequest ServiceRequest { get; set; }

        public RequestServiceModel(AppDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            // Load any data if needed (not required here)
        }

        public IActionResult OnPost()
        {
            _context.ServiceRequests.Add(ServiceRequest);
            _context.SaveChanges();

            TempData["SuccessMessage"] = "Your service request has been submitted successfully!";
            return RedirectToPage("RequestService");

        }

    }
}
