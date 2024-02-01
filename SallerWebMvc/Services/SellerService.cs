using SallerWebMvc.Data;
using SallerWebMvc.Models;
namespace SallerWebMvc.Services;

public class SellerService
{
    private readonly  SallerWebMvcContext _context;

    public SellerService(SallerWebMvcContext context)
    {
        _context = context;
    }

    //Listar todos vendedores
    public List<Seller> FindAll()
    {
        return _context.Seller.ToList();
    }

    //Metodo para inserir no banco de dados
    public void Insert(Seller objeto) 
    {
        objeto.Department = _context.Department.First();
        _context.Add(objeto);
        _context.SaveChanges();
    }
}
