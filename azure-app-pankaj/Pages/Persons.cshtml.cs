using azure_app_pankaj.Modal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace azure_app_pankaj.Pages
{
    [BindProperties]
    public class PersonsModel : PageModel
    {
        private readonly appDBContext appDBContext;
        public PersonsModel(appDBContext _appDBContext)
        {
            appDBContext = _appDBContext;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public List<Person> Persons { get; set; }
        public async Task<IActionResult> OnGet()
        {
            Persons = await appDBContext.Person.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            Person person = new Person();
            person.Name = Name;
            person.Email = Email;
            person.Phone = Phone;
            person.Address = Address;
            person.City = City;
            appDBContext.Person.Add(person);
            await appDBContext.SaveChangesAsync();

            return RedirectToPage("Persons");
        }
    }
}
