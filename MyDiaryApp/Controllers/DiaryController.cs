using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyDiaryApp.Models.AppDbContext;
using MyDiaryApp.Models.AppDbContext.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace MyDiaryApp.Controllers
{
    public class DiaryController : Controller
    {
        readonly private AppDbContext dbContext;
        public DiaryController(AppDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        //Get Index All Of Diaries
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await dbContext.Diaries.ToListAsync());
        }

        //Get Create New Diary
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }   
        //Post Create New Diary
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Diary diary)
        {
            if (ModelState.IsValid)
            {
                dbContext.Diaries.Add(diary);
                await dbContext.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View();
        }
        //Get Edit Diary
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) { return NotFound(); }

            var diary = await dbContext.Diaries.FindAsync(id);

            if (diary == null) { return NotFound(); }

            return View(diary);
        }     
        //Get Edit Diary
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,Diary diary)
        {
            if (id!=diary.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    dbContext.Diaries.Update(diary);
                    await dbContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!dbContext.Diaries.Any(model=>model.Id==id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return View(diary);
        }

        //Get Details Diary
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) { return NotFound(); }

            var diary=await dbContext.Diaries.FindAsync(id);

            if (diary == null)
            {
                return NotFound();
            }
            
            return View(diary);
        }
        //Get Delete Diary
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) { return NotFound(); }

            var diary=await dbContext.Diaries.FindAsync(id);

            if (diary == null)
            {
                return NotFound();
            }
            
            return View(diary);
        }
        //Post Delete Diary
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == null) { return NotFound(); }

            var diary=await dbContext.Diaries.FindAsync(id);
            dbContext.Diaries.Remove(diary);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
