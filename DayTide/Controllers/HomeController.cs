﻿using DayTide.Models;
using DayTide.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DayTide.Controllers
{
    public class HomeController : Controller
    {
        ProductRepository productRepository = new ProductRepository();
        CategoryRepository categoryRepository = new CategoryRepository();
        public ActionResult Index()
        {
            return View(productRepository.GetAll());
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.abc = categoryRepository.GetAll();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            productRepository.Insert(product);
            return View();
        }

        public ActionResult OnlyView(int id)
        {
            return View(productRepository.GetCategoryById(id));
        }

        [HttpGet]
        public ActionResult FullView(int id)
        {
            if(Session["userid"]==null)
            {
                return RedirectToAction("Index");
            }
            
            return View(productRepository.GetCategoryById(id));
        }

    }
}