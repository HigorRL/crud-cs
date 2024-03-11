using Microsoft.AspNetCore.Mvc;
using CadastroClientesAPI.Models; // Para referenciar a classe Cliente
using CadastroClientesAPI.Data; // Para referenciar a classe ClienteContext


[Route("api/[controller]")]
[ApiController]
public class ClientesController : ControllerBase
{
    private readonly ClienteContext _context;

    public ClientesController(ClienteContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetClientes()
    {
        var clientes = _context.Clientes.ToList();
        return Ok(clientes);
    }

    [HttpGet("{id}")]
    public IActionResult GetCliente(int id)
    {
        var cliente = _context.Clientes.Find(id);
        if (cliente == null)
            return NotFound();
        return Ok(cliente);
    }

    [HttpPost]
    public IActionResult PostCliente(Cliente cliente)
    {
        if (_context.Clientes.Any(c => c.CNPJ == cliente.CNPJ))
            return Conflict("CNPJ duplicado");

        cliente.DataCadastro = DateTime.Now;
        _context.Clientes.Add(cliente);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
    }

    [HttpPut("{id}")]
    public IActionResult PutCliente(int id, Cliente cliente)
    {
        if (id != cliente.Id)
            return BadRequest();

        var existingCliente = _context.Clientes.Find(id);
        if (existingCliente == null)
            return NotFound();

        existingCliente.Nome = cliente.Nome;
        existingCliente.CNPJ = cliente.CNPJ;
        existingCliente.Endereco = cliente.Endereco;
        existingCliente.Telefone = cliente.Telefone;

        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCliente(int id)
    {
        var cliente = _context.Clientes.Find(id);
        if (cliente == null)
            return NotFound();

        _context.Clientes.Remove(cliente);
        _context.SaveChanges();
        return NoContent();
    }
}
