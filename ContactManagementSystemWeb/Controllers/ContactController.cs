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
        private readonly string _baseUrl;

        public ContactController(IConfiguration configuration)
        {
            Configuration = configuration;
            _baseUrl = Configuration["BaseUrl"];
        }

        // GET: ContactController
        public async Task<ActionResult> Index()
        {
            client.BaseAddress = new Uri(_baseUrl);
            var contacts = await client.GetFromJsonAsync<List<Contact>>("contact");

            return View(contacts);
        }

        // GET: ContactController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ContactController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: ContactController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ContactController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
