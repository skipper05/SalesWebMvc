using Microsoft.AspNetCore.Mvc;
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
    }
}
