using Microsoft.AspNetCore.Mvc;
using SallerWebMvc.Models;
using SallerWebMvc.Models.ViewModels;
using SallerWebMvc.Services;

namespace SallerWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService; //criando uma imjeção de dependencia com SellerService
        private readonly DepartmentService _departmentService; //criando uma injeção com depenência com DepartmentService

        public SellersController(SellerService sellerService, DepartmentService departmentService) //construtor com injeção de dependencia do SellerService
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll(); // chamando o metodo FindAll da classe SellerService com a variável _sellerService e passando a list no método view

            return View(list);
        }

        
        public IActionResult Create()
        {
            var departments = _departmentService.FindAll(); //buscando os departamentos no banco de dados
            var viewModel = new SellerFormViewModel { Departments = departments }; //instanciando viewModel e recebendo a lista de departamentos
            return View(viewModel);
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
