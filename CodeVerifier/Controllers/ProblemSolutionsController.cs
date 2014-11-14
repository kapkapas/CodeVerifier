using System.Net;
using System.Web.Mvc;
using CodeVerifier.Models;

namespace CodeVerifier.Controllers
{
    public class ProblemSolutionsController : Controller
    {
        private MaidDbContext db = new MaidDbContext();

   

        // GET: ProblemSolutions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProblemSolutions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProblemId,SolutionCode")] ProblemSolution problemSolution)
        {
            if (ModelState.IsValid)
            {
                db.ProblemSolutions.Add(problemSolution);
                db.SaveChanges();
                string result = string.Empty;
                bool blah=ProblemSolution.CompileCodeToFile(problemSolution.SolutionCode.ToString(),problemSolution.ProblemId.ToString(),ref result);
               
                    return RedirectToAction("Index", "Problems");
               
            }

            return View(problemSolution);
        }



        // GET: ProblemSolutions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProblemSolution problemSolution = db.ProblemSolutions.Find(id);
            if (problemSolution == null)
            {
                return HttpNotFound();
            }
            return View(problemSolution);
        }

        // POST: ProblemSolutions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProblemSolution problemSolution = db.ProblemSolutions.Find(id);
            db.ProblemSolutions.Remove(problemSolution);
            db.SaveChanges();
            return RedirectToAction("Index","Problems");
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
