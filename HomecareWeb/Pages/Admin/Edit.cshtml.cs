using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HomecareWeb.Data;
using HomecareWeb.Models;

namespace HomecareWeb.Pages.Admin
{
    public class EditModel : PageModel
    {
        private readonly AppDbContext _context;

        public EditModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ServiceRequest ServiceRequest { get; set; }

        public IActionResult OnGet(int id)
        {
            ServiceRequest = _context.ServiceRequests.Find(id);

            if (ServiceRequest == null)
            {
                return RedirectToPage("RequestList");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Model valid? " + ModelState.IsValid);
                foreach (var err in ModelState)
                {
                    foreach (var subErr in err.Value.Errors)
                    {
                        Console.WriteLine($"Error in {err.Key}: {subErr.ErrorMessage}");
                    }
                }

                return Page();
            }

            var existing = _context.ServiceRequests.Find(ServiceRequest.Id);

            if (existing == null)
            {
                return RedirectToPage("RequestList");
            }

            existing.FullName = ServiceRequest.FullName;
            existing.PhoneNumber = ServiceRequest.PhoneNumber;
            existing.Email = ServiceRequest.Email;
            existing.RequestedService = ServiceRequest.RequestedService;
            existing.Notes = ServiceRequest.Notes;

            _context.SaveChanges();

            return RedirectToPage("RequestList");
        }
    }
}
