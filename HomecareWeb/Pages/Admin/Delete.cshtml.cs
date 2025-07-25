using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HomecareWeb.Data;
using HomecareWeb.Models;

namespace HomecareWeb.Pages.Admin
{
    public class DeleteModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteModel(AppDbContext context)
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
            var request = _context.ServiceRequests.Find(ServiceRequest.Id);

            if (request != null)
            {
                _context.ServiceRequests.Remove(request);
                _context.SaveChanges();
            }

            return RedirectToPage("RequestList");
        }
    }
}
