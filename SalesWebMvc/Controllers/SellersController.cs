using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models;
using SalesWebMvc.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }



        public IActionResult Index() //Acessa o CONTROLADOR , ele chama o MODEL,
        {
            var list = _sellerService.FindAll(); //O Model Pega os dados na Lista.

            return View(list); //E encaminha para a VIEW (Conceito MVC) 
        }

        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost] //Anotação Para entender que a requisição é um método POST
        [ValidateAntiForgeryToken] //Anotação para evitar ataques CSRF
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }


    }
}
