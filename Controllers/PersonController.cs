using PPPK_Delivery_6_CosmosOsoba.Dao;
using PPPK_Delivery_6_CosmosOsoba.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PPPK_Delivery_6_CosmosOsoba.Controllers
{
    public class PersonController : Controller
    {
        private static readonly ICosmosDbService service = CosmosDbServiceProvider.CosmosDbService;

        // GET: Person
        public async Task<ActionResult> Index()
        {
            return View(await service.GetPeopleAsync("select * from People"));
        }

        // GET: Person/Details/5
        public async Task<ActionResult> Details(string id)
        {
            return await ShowPerson(id);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "Id, Fullname, Dob")] Person person)
        {
            if (ModelState.IsValid)
            {
                person.Id = Guid.NewGuid().ToString();
                await service.AddPersonAsync(person);
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: Person/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            return await ShowPerson(id);
        }

        private async Task<ActionResult> ShowPerson(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var person = await service.GetPersonAsync(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Include = "Id, Fullname, Dob")] Person person)
        {
            if (ModelState.IsValid)
            {
                await service.UpdatPersonAsync(person);
                return RedirectToAction("Index");
            }

            return View(person);
        }

        // GET: Person/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            return await ShowPerson(id);
        }

        // POST: Person/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete([Bind(Include = "Id, Fullname, Dob")] Person person)
        {
            await service.DeletePersonAsync(person);
            return RedirectToAction("Index");
        }
    }
}
