namespace SallerWebMvc.Models;
using System.Linq;
public class Seller
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public DateTime BirthDate { get; set; }
    public double Salary { get; set; }
    public Department? Department { get; set; } //associação um vendedor esta em um departamento
    public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>(); //um vendedor pode ter varias vendas
    public Seller() { }

    public Seller(int id, string name, string email, DateTime birthDate, double salary, Department department)
    {
        Id = id;
        Name = name;
        Email = email;
        BirthDate = birthDate;
        Salary = salary;
        Department = department;
    }

    public void AddSalles(SalesRecord sr)
    {
        Sales.Add(sr);
    }
    public void RemoveSalles(SalesRecord rs)
    {
        Sales.Remove(rs);
    }

    public double TotalSalles(DateTime initial, DateTime final)
    {
        return Sales.Where(s => s.Date >= initial && s.Date <= final).Sum(s => s.Amount);
    }
}
