using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DimensaoTeste.Models;

namespace DimensaoTeste.Controllers
{
    public class TaskListsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TaskLists
        public ActionResult Index()
        {
            return View();
        }

        private IEnumerable<TaskList> GetTaskLists()
        {
            string IdUsuarioLogado = User.Identity.GetUserId();
            ApplicationUser usuarioLogado = db.Users.FirstOrDefault
                (x => x.Id == IdUsuarioLogado);

            IEnumerable<TaskList> myTasks= db.TaskLists.ToList().Where(x => x.Usuario == usuarioLogado);

            int completos = 0;
            foreach (TaskList task in myTasks)
            {
                if (task.Situacao)
                {
                    completos++;
                }
            }
            
            if ((float)myTasks.Count() > 0)
            {
                ViewBag.Percentual = Math.Round(100 * ((float)completos / (float)myTasks.Count()));
            } else {
                ViewBag.Percentual = 0;
            }

            return myTasks;
        }

        public ActionResult BuildTaskListTable()
        {
            return PartialView("_TaskListTable",GetTaskLists());
        }


        // GET: TaskLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskList taskList = db.TaskLists.Find(id);
            if (taskList == null)
            {
                return HttpNotFound();
            }
            return View(taskList);
        }

        // GET: TaskLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TaskLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Titulo,Descricao,Situacao")] TaskList taskList)
        {
            if (ModelState.IsValid)
            {
                string IDUsuarioLogado = User.Identity.GetUserId();
                ApplicationUser usuarioLogado = db.Users.FirstOrDefault
                    (x => x.Id == IDUsuarioLogado);
                taskList.Usuario = usuarioLogado;
                db.TaskLists.Add(taskList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(taskList);
        }

        // GET: TaskLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskList taskList = db.TaskLists.Find(id);
            if (taskList == null)
            {
                return HttpNotFound();
            }
            return View(taskList);
        }

        // POST: TaskLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Titulo,Descricao,Situacao")] TaskList taskList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(taskList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taskList);
        }


        [HttpPost]
        public ActionResult AJAXEdit(int? id, Boolean value)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskList taskList = db.TaskLists.Find(id);
            if (taskList == null)
            {
                return HttpNotFound();
            } else
            {
                taskList.Situacao = value;
                db.Entry(taskList).State = EntityState.Modified;
                db.SaveChanges();
                return PartialView("_TaskListTable", GetTaskLists());
            }
        }



        // GET: TaskLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaskList taskList = db.TaskLists.Find(id);
            if (taskList == null)
            {
                return HttpNotFound();
            }
            return View(taskList);
        }

        // POST: TaskLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TaskList taskList = db.TaskLists.Find(id);
            db.TaskLists.Remove(taskList);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
