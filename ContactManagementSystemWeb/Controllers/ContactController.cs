using ContactManagementSystemModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ContactManagementSystemWeb.Controllers
{
    public class ContactController : Controller
    {
        HttpClient client = new HttpClient();
        private readonly IConfiguration Configuration;

        public ContactController(IConfiguration configuration)
        {
            Configuration = configuration;
            client.BaseAddress = new Uri(Configuration["BaseUrl"]);
        }

        // GET: ContactController
        public async Task<ActionResult> Index()
        {
            var contacts = await client.GetFromJsonAsync<List<Contact>>("contact");

            return View(contacts);
        }

        // GET: ContactController/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await client.GetFromJsonAsync<Contact>("contact/" + id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // GET: ContactController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,JobTitle,Company,Address,Phone,Email,LastContactedDate,Comments,CreatedDate")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = await client.PostAsJsonAsync("contact/", contact);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch
                {
                    return View(contact);
                }
            }
            return View(contact);
        }

        // GET: ContactController/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contact = await client.GetFromJsonAsync<Contact>("contact/" + id);
            if (contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: ContactController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,JobTitle,Company,Address,Phone,Email,LastContactedDate,Comments,CreatedDate")] Contact contact)
        {
            if (id != contact.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var response = await client.PutAsJsonAsync("contact/" + id, contact);
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch
                {
                    return View(contact);
                }
            }
            return View(contact);
        }

        // GET: ContactController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ContactController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
