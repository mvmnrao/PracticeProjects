using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageTrainingApp.Controllers
{
    public class ImageTrainController : Controller
    {
        // GET: ImageTrain
        public ActionResult Index()
        {
            return View();
        }

        // GET: ImageTrain/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ImageTrain/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImageTrain/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ImageTrain/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ImageTrain/Edit/5
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

        // GET: ImageTrain/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ImageTrain/Delete/5
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
