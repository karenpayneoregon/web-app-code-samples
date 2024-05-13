using EntityFrameworkLibrary;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NorthWindExampleApp4.Classes;
using NorthWindExampleApp4.Data;
using NorthWindExampleApp4.Models;


namespace NorthWindExampleApp4.Pages
{
    public class CustomerViewModel : PageModel
    {
        private readonly Context _context;

        public CustomerViewModel(Context context)
        {
            _context = context;
        }

        public IList<Customers> CustomersList { get;set; } = default!;

        public SelectList ColumnList { get; set; }
        [BindProperty]
        public List<SqlColumn> SqlColumns { get; set; }

        [BindProperty]
        public int SelectedIndex { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Customers != null)
            {
                CustomersList = await OrderByOnNavigation("CountryIdentifierNavigation.Name");
                
                // TODO This is broken
                SqlColumns = _context.GetModelProperties(nameof(CustomersList));
                //ColumnList = new SelectList(SqlColumns, "Id", "Name");
            }

        }

        public async Task OnPostSubmit(int id)
        {
            SqlColumns = _context.GetModelProperties(nameof(CustomersList));
            var current = SqlColumns.FirstOrDefault(x => x.Id == id);
            if (current!.IsNavigation)
            {
                CustomersList = await OrderByOnNavigation(current.NavigationValue);
            }
            else
            {
                CustomersList = await OrderByOnNavigation(current.Name);
            }

            ColumnList = new SelectList(SqlColumns, "Id", "Name");
            SelectedIndex = id;
            ViewData["JavaScript"] = id;
        }

        public async Task<List<Customers>> OrderByOnNavigation(string ordering)
        {

            return await _context.Customers
                .Include(c => c.CountryIdentifierNavigation)
                .Include(c => c.Contact)
                .Include(c => c.ContactTypeIdentifierNavigation)
                .OrderByColumn(ordering)
                .ToListAsync();

        }
    }
}
