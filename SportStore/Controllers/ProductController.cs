﻿using SportStore.Domain.Abstract;
using SportStore.Domain.Entities;
using SportStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository repository;
        public int PageSize = 4;
        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        //Adding Pagination Support to the List Action Method in the ProductController.cs File
        public ViewResult List(string category,int page=1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
               Products = repository.Products
                .Where(p=>category==null || p.Category==category)
                .OrderBy(p => p.ProductID)
                .Skip((page-1 ) * PageSize)
                .Take(PageSize),

            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = PageSize,
                TotalItems = category == null ?
                repository.Products.Count() :
                repository.Products.Where(e => e.Category == category).Count()
            },
            CurrentCategory=category
            };
                return View(model);
        }
        public FileContentResult GetImage(int productId)
        {
            Product prod = repository.Products
                .FirstOrDefault(p => p.ProductID == productId);
            if (prod!=null)
            {
                return File(prod.ImageData, prod.ImageMimeType);
            }
            else
            {
                return null;
            }
        }


    }
}
