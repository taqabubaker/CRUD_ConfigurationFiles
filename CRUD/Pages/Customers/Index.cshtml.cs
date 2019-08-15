using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Data;
using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CRUD.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly AppDbContext _db;
        private readonly IConfiguration _config; 

        public IndexModel(AppDbContext db, IConfiguration configuration)
        {
            _db = db;
            _config = configuration;
        }

        public PaginatedList<Customer> Customers { get; set; }

        public async Task<IActionResult> OnGetAsync(int? pageIndex)
        {
            int? pageSize = _config.GetValue<int>("AppSettings:PagingSize");

            Customers = await PaginatedList<Customer>.CreateAsync(
                _db.Customers.AsNoTracking(), pageIndex ?? 1, pageSize ?? 3);

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteCustomerAsync(int id)
        {
            var customer = await _db.Customers.FindAsync(id);

            if (customer == null)
            {
                return Page();
            }

            _db.Customers.Remove(customer);
            await _db.SaveChangesAsync();
            return RedirectToPage();
        }
    }
}