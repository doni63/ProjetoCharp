namespace SallerWebMvc.Models;

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Seller> Sellers { get; set; } = new List<Seller>(); //um departamento possui varios vendedores

    //construtor sem argumentos e com argumentos
    public Department() { }

    public Department(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public void AddSeller(Seller seller)
    {
        Sellers.Add(seller);
    }

    public double TotalSalles(DateTime initial, DateTime final)
    {
        return Sellers.Sum(seller => seller.TotalSalles(initial, final));
    }
}
