using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ecomerce_back.Models;

[Route("api/Produit")]
[ApiController]
public class ProduitController : ControllerBase
{
    private readonly ProduitContext _context;

    public ProduitController(ProduitContext context)
    {
        _context = context;
    }

    // GET: api/Produit
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Produit>>> GetProduits()
    {
        return await _context.Produits.ToListAsync();
    }

    // GET: api/Produit/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Produit>> GetProduit(int id)
    {
        var Produit = await _context.Produits.FindAsync(id);
        if (Produit == null)
        {
            return NotFound();
        }
        return Produit;
    }

    // PUT: api/Produit/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduit(int id, Produit Produit)
    {
        if (id != Produit.Id)
        {
            return BadRequest();
        }
        _context.Entry(Produit).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProduitExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }
        return NoContent();
    }

    // POST: api/Produit
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Produit>> PostProduit(Produit Produit)
    {
        _context.Produits.Add(Produit);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetProduit", new { id = Produit.Id }, Produit);
    }

    // DELETE: api/Produit/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduit(int id)
    {
        var Produit = await _context.Produits.FindAsync(id);
        if (Produit == null)
        {
            return NotFound();
        }
        _context.Produits.Remove(Produit);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private bool ProduitExists(int id)
    {
        return _context.Produits.Any(e => e.Id == id);
    }
}