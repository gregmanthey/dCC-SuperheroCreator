﻿using SuperheroCreator.Models;
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
        public ActionResult Details(Superhero superhero)
        {
            return View(superhero);
        }

        // GET: Superheroes/Create
        public ActionResult Create()
        {
            Superhero superhero = new Superhero();
            return Details(superhero);
        }

        // POST: Superheroes/Create
        [HttpPost]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                context.Superheroes.Add(superhero);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Superheroes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Superheroes/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Superheroes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Superheroes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
