using Microsoft.AspNetCore.Mvc;
using SallerWebMvc.Models;
using SallerWebMvc.Services;

namespace SallerWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService; //criando uma imjeção de dependencia com SellerService

        public SellersController(SellerService sellerService) //construtor com injeção de dependencia do SellerService
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll(); // chamando o metodo FindAll da classe SellerService com a variável _sellerService e passando a list no método view

            return View(list);
        }

        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            //redirecionar para index de seller
            return RedirectToAction(nameof(Index));
        }
    }
}
