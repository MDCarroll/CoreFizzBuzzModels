using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoreFizzBuzzModels.Models;
using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CoreFizzBuzzModels.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Solve()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Solve(int input1, int input2)
        {

            var model = new FizzBuzzModel()
            {
                FizzNum = Convert.ToInt32(input1),
                BuzzNum = Convert.ToInt32(input2),
                Output = $"You gave me FizzNum: {input1} and BuzzNumb: {input2} <hr/>"
            };

            var output = new StringBuilder();
            for (var index = 1; index <= 100; index++)
            {
                if (index % input1 == 0 && index % input2 == 0)
                {
                    model.Output += "<span class='fizzBuzz'> FizzBuzz </span>";
                }
                else if (index % input2 == 0)
                {
                    model.Output += "<span class='buzz'> Buzz </span>";
                }
                else if (index % input1 == 0)
                {
                    model.Output += "<span class='fizz'> Fizz </span>";
                }
                else
                {
                    model.Output +=$"<span class='miss'> {index} </span>";
                }

            }
        ViewData["Output"] = output.ToString();
            return View("Result", model);
        }

        public IActionResult Result(FizzBuzzModel model)
        {
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
