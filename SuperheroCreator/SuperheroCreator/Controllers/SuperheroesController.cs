using SuperheroCreator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperheroCreator.Controllers
{
    public class SuperheroesController : Controller
    {
        ApplicationDbContext context;
        public SuperheroesController()
        {
            context = new ApplicationDbContext();
        }
        // GET: Superheroes
        public ActionResult Index()
        {
            return View(context.Superheroes);
        }

        // GET: Superheroes/Details/5
        public ActionResult Details(int id)
        {
            var superheroFoundInDb = GetSuperheroFromId(id);
            if (superheroFoundInDb is null)
            {
                return RedirectToAction("Index");
            }
            return View(superheroFoundInDb);
        }

        // GET: Superheroes/Create
        public ActionResult Create()
        {
            Superhero superhero = new Superhero();
            return View(superhero);
        }

        // POST: Superheroes/Create
        [HttpPost]
        public ActionResult Create(Superhero superhero)
        {
            if (!(superhero.Name is null))
            {
                context.Superheroes.Add(superhero);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                Console.WriteLine("Error creating superhero, name cannot be null");
                return RedirectToAction("Create");
            }
        }

        // GET: Superheroes/Edit/5
        public ActionResult Edit(int id)
        {
            return View(GetSuperheroFromId(id));
        }

        // POST: Superheroes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Superhero superhero)
        {
            var superheroFoundInDb = GetSuperheroFromId(id);
            if (superheroFoundInDb is null)
            {
                return RedirectToAction("Index");
            }
            superheroFoundInDb.Name = superhero.Name;
            superheroFoundInDb.AlterEgo = superhero.AlterEgo;
            superheroFoundInDb.PrimaryAbility = superhero.PrimaryAbility;
            superheroFoundInDb.SecondaryAbility = superhero.SecondaryAbility;
            superheroFoundInDb.Catchphrase = superhero.Catchphrase;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Superheroes/Delete/5
        public ActionResult Delete(int id)
        {
            return View(GetSuperheroFromId(id));
        }

        // POST: Superheroes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Superhero superhero)
        {
            var superheroFoundInDb = GetSuperheroFromId(id);
            if (superheroFoundInDb is null)
            {
                return RedirectToAction("Index");
            }
            context.Superheroes.Remove(superheroFoundInDb);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        private Superhero GetSuperheroFromId(int id)
        {
            return context.Superheroes.Where(s => s.Id.Equals(id)).FirstOrDefault();
        }
    }
}
