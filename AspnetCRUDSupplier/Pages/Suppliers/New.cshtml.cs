using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AspnetCRUDSupplier.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AspnetCRUDSupplier.Pages.Suppliers
{
    public class NewModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        [BindProperty]
        [Required]
        [MaxLength(40)]
        public string CompanyName { get; set; }

        [BindProperty]
        [MaxLength(30)]
        public string ContactName { get; set; }

        [BindProperty]
        [MaxLength(30)]
        public string ContactTitle { get; set; }

        [BindProperty]
        [MaxLength(60)]
        public string Address { get; set; }
        [BindProperty]
        [MaxLength(15)]
        public string City { get; set; }

        [BindProperty]
        [MaxLength(10)]
        public string PostalCode { get; set; }

        [BindProperty]
        [MaxLength(15)]
        public string Country { get; set; }
        [BindProperty]
        [MaxLength(24)]
        public string Phone { get; set; }

        [BindProperty]
        [MaxLength(24)]
        public string Fax { get; set; }

        [BindProperty]
        [MaxLength(150)]
        public string Homepage { get; set; }


        [BindProperty]
        [Required]
        public string SelectedSupplierType { get; set; }
        public List<SelectListItem> AllSupplierTypes { get; set; }


        public NewModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            SetAllSupplierTypes();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var s = new Supplier();
                _context.Supplier.Add(s);
                
                s.CompanyName = CompanyName;
                s.Address = Address;
                s.City = City;
                s.ContactName = ContactName;
                s.ContactTitle = ContactTitle;
                s.Country = Country;
                s.Fax = Fax;
                s.Homepage = Homepage;
                s.Phone = Phone;
                s.PostalCode = PostalCode;
                s.SupplierType = Enum.Parse<Supplier.SupplierTypeEnum>(SelectedSupplierType);

                _context.SaveChanges();
                return RedirectToPage("Index");
            }

            SetAllSupplierTypes();
            return Page();
        }

        void SetAllSupplierTypes()
        {
            AllSupplierTypes = Enum.GetValues<Supplier.SupplierTypeEnum>()
                .Select(r => new SelectListItem(r.ToString(), r.ToString())).ToList();
            AllSupplierTypes.Insert(0, new SelectListItem("Välj en",""));
        }
    }
}
