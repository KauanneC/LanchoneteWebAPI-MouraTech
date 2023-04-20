using Lanchonete.Models;

namespace Lanchonete.Service;

public static class LancheServices
{
    static List<Lanche> lanches { get; } //Criou a lista
    static int nextId = 4;

    // Constructor
    static LancheServices()
    {
        lanches = new List<Lanche> //Preenchimento da lista
        {
            new Lanche
            {
                id = 1,
                nome = "X-Bacon",
                preco = 10.00,
                vegetariano = false,
                tipoCarne = "Bovina"
            },
            new Lanche
            {
                id = 2,
                nome = "Pastel de soja",
                preco = 6.50,
                vegetariano = true,
                tipoCarne = "Soja"
            },
            new Lanche
            {
                id = 3,
                nome = "Cachorro-Quente",
                preco = 5.00,
                vegetariano = false,
                tipoCarne = "Carne moída"
            }  
        };
    }

    public static List<Lanche> getAll() => lanches; //Listar todos
    public static Lanche? get(int id) // Listar o lanche pelo id
    {
        return lanches.FirstOrDefault(p => p.id == id);
    }
    public static void add(Lanche lanche) // Add um lanche
    {
        lanche.id = nextId++;
        lanches.Add(lanche);
    }
    public static void delete(int id) // remover um lanche
    {
        var lanche = get(id);
        if (lanche is null){
            return;
        }    
        lanches.Remove(lanche);
    }
    public static void update(Lanche lanche) // atualizar um lanche
    {
        var index = lanches.FindIndex(p => p.id == lanche.id);
        if (index == -1){
            return;
        }
        lanches[index] = lanche;
    }
}
