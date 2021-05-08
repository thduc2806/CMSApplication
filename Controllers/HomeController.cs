using AssigmentCode.Data;
using AssigmentCode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AssigmentCode.Controllers
{
	public class HomeController : Controller
	{
		private readonly CMSContext context;

		public HomeController(CMSContext context)
		{
			this.context = context;
		}

		public IActionResult Index()
		{
			ViewBag.IsLoginFail = "hidden";
			ViewBag.IsWrong = "";
			return View();
		}

		[HttpPost]
		[AutoValidateAntiforgeryToken]
		public IActionResult Index(string role, string username, string password)
		{
			if (username == null || password == null)
			{
				ViewBag.IsWrong = "is-invaled";
			}
			else
			{
				if (role == new Admin().GetType().Name)
				{
					try
					{
						var admin = context.Admins.Where(admin => admin.Username == username && admin.Password == password).Single();
						SingleTon.getIntance().Username = admin.Username;
						SingleTon.getIntance().Role = role;
						return RedirectToAction("Index", "Admins");
					}
					catch(Exception exception)
					{
						Console.WriteLine(exception);
						ViewBag.IsWrong = "";
						return View();
					}
				}
				if (role == new Training().GetType().Name)
				{
					try
					{
						var training = context.Trainings.Where(training => training.Username == username && training.Password == password).Single();
						SingleTon.getIntance().Username = training.Username;
						SingleTon.getIntance().Role = role;
						return RedirectToAction("Index", "Trainners");
					}
					catch (Exception exception)
					{
						Console.WriteLine(exception);
						ViewBag.IsWrong = "";
						return View();
					}
				}
				if (role == new Trainner().GetType().Name)
				{
					try
					{
						var trainner = context.Trainners.Where(trainner => trainner.Username == username && trainner.Password == password).Single();
						SingleTon.getIntance().Username = trainner.Username;
						SingleTon.getIntance().Role = role;
						return RedirectToAction("Index", "TrainnersManage");
					}
					catch (Exception exception)
					{
						Console.WriteLine(exception);
						ViewBag.IsWrong = "";
						return View();
					}
				}
			}
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
