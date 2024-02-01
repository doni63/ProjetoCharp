using SallerWebMvc.Data;
using SallerWebMvc.Models;

namespace SallerWebMvc.Services;
public class DepartmentService
{
    private readonly SallerWebMvcContext _context;

    public DepartmentService(SallerWebMvcContext context)
    {
        _context = context;
    }

    public List<Department> FindAll()
    {
        return _context.Department.OrderBy(x => x.Name).ToList();
    }
}
