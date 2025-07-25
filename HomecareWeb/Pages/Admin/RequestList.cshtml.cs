using Microsoft.AspNetCore.Authorization; 
using Microsoft.AspNetCore.Mvc.RazorPages;
using HomecareWeb.Data;
using HomecareWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace HomecareWeb.Pages.Admin
{
    [Authorize] 
    public class RequestListModel : PageModel
    {
        private readonly AppDbContext _context;

        public RequestListModel(AppDbContext context)
        {
            _context = context;
        }

        public List<ServiceRequest> Requests { get; set; } = new();

        public void OnGet()
        {
            Requests = _context.ServiceRequests
                .OrderByDescending(r => r.SubmittedAt)
                .ToList();
        }
    }
}
