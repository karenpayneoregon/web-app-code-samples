using CheckedListBox.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
#pragma warning disable CS8618

namespace CheckedListBox.Pages
{
    public class Index1Model : PageModel
    {

        [BindProperty]
        public List<ServiceModel> CheckModels { get; set; }

        public Index1Model()
        {
            LoadStuff();
        }
        public void OnGet() { }

        private void LoadStuff()
        {
            CheckModels = new List<ServiceModel>
            {
                new() {Id = 1,  Name = "Headlights", Checked = false},
                new() {Id = 2,  Name = "Brake Light Switches", Checked = false},
                new() {Id = 3,  Name = "Wiper Switches", Checked = false},
                new() {Id = 4,  Name = "Door Jamb Switches", Checked = false}
            };
        }

        public Task<IActionResult> OnPostResendAsync()
        {
            return Task.FromResult<IActionResult>(RedirectToPage("Index1"));
        }
    }
}
