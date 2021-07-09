using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetCRUDSupplier.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspnetCRUDSupplier.Pages.Suppliers
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public List<SupplierListViewModel> Items { get; set; }

        public class SupplierListViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }


        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Items = _context.Supplier.Select(r => new SupplierListViewModel
            {
                Id = r.Id,
                Name = r.CompanyName
            }).ToList();
        }
    }
}
