using Microsoft.Identity.Client;

namespace Ecomerce_back.Models;
public class Produit
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public int? Price { get; set; }

    public string? Category { get; set; }

    public int? Stock { get; set; }

    public string? Image { get; set; }

}