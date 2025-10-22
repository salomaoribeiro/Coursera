namespace Coursera.Controllers;

using Coursera.Models;
using Coursera.Repository;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProdutoController : ControllerBase
{
    // GET: api/produto
    [HttpGet]
    public ActionResult<IEnumerable<Produto>> Get()
    {
        return Ok(ProdutoRepository.GetAll());
    }

    // GET: api/produto/{id}
    [HttpGet("{id}")]
    public ActionResult<Produto> Get(int id)
    {
        var produto = ProdutoRepository.GetById(id);
        if (produto == null)
            return NotFound();

        return Ok(produto);
    }

    // POST: api/produto
    [HttpPost]
    public ActionResult<Produto> Post([FromBody] Produto produto)
    {
        var novoProduto = ProdutoRepository.Add(produto);
        return CreatedAtAction(nameof(Get), new { id = novoProduto.Id }, novoProduto);
    }

    // PUT: api/produto/{id}
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Produto produto)
    {
        if (id != produto.Id)
            return BadRequest();

        var existente = ProdutoRepository.GetById(id);
        if (existente == null)
            return NotFound();

        ProdutoRepository.Update(produto);
        return NoContent();
    }

    // DELETE: api/produto/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var produto = ProdutoRepository.GetById(id);
        if (produto == null)
            return NotFound();

        ProdutoRepository.Delete(id);
        return NoContent();
    }
}
