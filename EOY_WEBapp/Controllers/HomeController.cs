﻿using EOY_WEBapp.Data;
using EOY_WEBapp.Models;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Text.Json;

namespace EOY_WEBapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly EOY_Values _values = new EOY_Values();


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AccountSettings()
        {
            return RedirectToAction("Index","Account");
        }
        public IActionResult ActualReport()
        {
            return RedirectToAction("Index", "Report");
        }



    }
}
