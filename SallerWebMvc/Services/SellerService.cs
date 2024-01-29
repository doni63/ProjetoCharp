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

    public List<Seller> FindAll()
    {
        return _context.Seller.ToList();
    }
}
