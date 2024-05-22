using Jidelnicek.web.Data;
using Jidelnicek.web.Models;
using Jidelnicek.web.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Jidelnicek.web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly AppDbContext dbContext;
        private readonly IStringLocalizer<HomeController> _localizer;
        public StudentsController(AppDbContext dbContext, IStringLocalizer<HomeController> localizer)
        {
            this.dbContext = dbContext;
            _localizer = localizer;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost] 
        public  async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            var student = new Menu
            {
                Number = viewModel.Number,
                Dish = viewModel.Dish,
                Grams = viewModel.Grams,
                Price = viewModel.Price,
                Subscribed = viewModel.Subscribed,
            };


            await dbContext.Menu.AddAsync(student);
            await dbContext.SaveChangesAsync();



            return View();
        }


        [HttpGet]
        public async Task<IActionResult> List()
        {
            var str = _localizer["WelcomeMessage"].Value;
            var students = await dbContext.Menu.ToListAsync();

            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var student = await dbContext.Menu.FindAsync(Id);

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Menu viewModel)
        {
            var student = await dbContext.Menu.FindAsync(viewModel.Id);

            if (student is not null) 
            {
                student.Dish = viewModel.Dish;
                student.Grams = viewModel.Grams;   
                student.Price = viewModel.Price;
                student.Subscribed = viewModel.Subscribed;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Menu viewModel)
        {
            var student = await dbContext.Menu
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);

            if (student is not null)
            {
                dbContext.Menu.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");
        }
    }
}
