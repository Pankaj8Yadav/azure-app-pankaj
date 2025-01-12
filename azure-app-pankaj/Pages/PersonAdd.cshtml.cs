using azure_app_pankaj.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace azure_app_pankaj.Pages
{
    [BindProperties]
    public class PersonAddModel : PageModel
    {
        private readonly AppDBContext _context;

        public PersonAddModel(AppDBContext context)
        {
            _context = context;
        }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public List<Person> Persons { get; set; }

        public async Task<IActionResult> OnGet()
        {
            Persons = await _context.persons.ToListAsync();
            return Page();
        }
        public async Task<IActionResult> OnPost()
        {
            Person person = new Person();
            person.Name = Name;
            person.Address = Address;
            person.City = City;
            person.Email = Email;
            person.Phone = Phone;

            if (ModelState.IsValid)
            {

                _context.persons.Add(person);
                await _context.SaveChangesAsync();


                return RedirectToAction("Index"); // Redirect to a page (e.g., list of persons)
            }
            return RedirectToPage("PersonAdd");
        }
    }
}
