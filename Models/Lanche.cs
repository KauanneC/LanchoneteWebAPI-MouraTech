namespace Lanchonete.Models;

public class Lanche{
    public int id { get; set; }
    public string? nome { get; set; }
    public double preco { get; set; }
    public bool vegetariano { get; set; }
    public string tipoCarne { get; set; }
}