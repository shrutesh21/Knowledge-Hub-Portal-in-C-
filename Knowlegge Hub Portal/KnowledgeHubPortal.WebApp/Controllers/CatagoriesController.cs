using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repository;
using konwledgeHubPortal.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KnowledgeHubPortal.WebApp.Controllers
{
    [Authorize(Roles = "admin")]
    public class CatagoriesController : Controller
    {
        ICatagoryRepository repo = null;
        public CatagoriesController(ICatagoryRepository repo)
        {
            this.repo = repo;
        }
        // .../catagories/index
        //public IActionResult Index()
        //{
        //    // fetch the catagories list from datalayer
        //    //ICatagoryRepository repo = new CatagoryRepository(); //BAD Way - DIP

        //    // send the list of catagories to view
        //    List<Catagory> catagories = repo.GetAll();

        //    return View(catagories);
        //}

        public async Task<IActionResult> IndexAsync()
        {
            // fetch the catagories list from datalayer
            //ICatagoryRepository repo = new CatagoryRepository(); //BAD Way - DIP

            // send the list of catagories to view
            List<Catagory> catagories = await repo.GetAllAsync();

            return View(catagories);
        }
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Save(Catagory catagory)
        {
            if (!ModelState.IsValid)
            {
                return View("Add"); // this code validates the values. this is server side validation
            }
            //ICatagoryRepository repo = new CatagoryRepository();
            repo.Create(catagory);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            // get the catagory object by ID
            //ICatagoryRepository repo = new CatagoryRepository();
            Catagory catagoryToEdit = repo.GetById(id);
            return View(catagoryToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Catagory catagory)
        {
            if (!ModelState.IsValid)
            {
                return View(""); // this code validates the values. this is server side validation
            }
            // get the catagory object by ID
            //ICatagoryRepository repo = new CatagoryRepository();
            repo.Update(catagory);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
			//ICatagoryRepository repo = new CatagoryRepository();
			repo.Delete(id);
			return RedirectToAction("Index");
		}

        public IActionResult SubmitURL()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitURL(Catagory catagory)
        {
            if (!ModelState.IsValid)
            {
                return View(catagory);
            }
            
            repo.Create(catagory);
            return RedirectToAction("Index");
        }
    }
}
