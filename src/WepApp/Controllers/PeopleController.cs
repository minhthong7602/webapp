using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WepApp.Models;
using System.Linq;
using WepApp.Infrastructure;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WepApp.Controllers
{
    public class PeopleController : Controller
    {
        private readonly PeopleContext _context;
        public PeopleController(PeopleContext peopleContext)
        {
            this._context = peopleContext;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index(string searchString)
        {
            var items = from m in _context.Peoples select m;
            if(!string.IsNullOrEmpty(searchString))
            {
                items = items.Where(s => s.Name.Contains(searchString));
            }
            return View(await items.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(People model)
        {
            if(ModelState.IsValid)
            {
                _context.Peoples.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int Id)
        {
            var p = await _context.Peoples.SingleOrDefaultAsync(m => m.Id == Id);
            _context.Remove(p);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int Id)
        {
            var p = await _context.Peoples.SingleOrDefaultAsync(m => m.Id == Id);
            return View(p);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var p = await _context.Peoples.SingleOrDefaultAsync(x => x.Id == Id);

            if (p == null)
            {
                return NotFound();
            }

            return View(p);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, People model)
        {
            if (ModelState.IsValid)
            {
                _context.Update(model);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(model);
            
        }




        //private readonly IPeopleService _peopleRepository;
        //public PeopleController(IPeopleService peopleRepository)
        //{
        //    this._peopleRepository = peopleRepository;
        //}
        //// GET: /<controller>/
        //public IActionResult Index()
        //{
        //    var item = _peopleRepository.GetAll();
        //    return View(item);
        //}

        //public IActionResult Welcome(string name)
        //{
        //    People p = new People { Name = name, Age = 23 };
        //    //_context.Peoples.Add(p);
        //    //_context.SaveChanges();
        //    return View(p);
        //}

        //[HttpGet]
        //public IActionResult Details(int Id)
        //{
        //    var p = _peopleRepository.GetById(Id);
        //    return View(p);
        //}

        //[HttpGet]
        //public IActionResult Edit(int? Id)
        //{
        //    if (Id == null)
        //    {
        //        return NotFound();
        //    }
        //    var p = _peopleRepository.GetById(Id.Value);

        //    if (p == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(p);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit(int Id, People model)
        //{
        //    var item = _peopleRepository.GetById(Id);
        //    item = model;
        //    _peopleRepository.Update(item);
        //    return RedirectToAction("Index");
        //}
    }
}