using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PantaNet.Api.Models;
using PantaNet.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace PantaNet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly DatabaseContext _db;

        public ProdutosController(DatabaseContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IEnumerable<Produto>> Get()
        {
            return await _db.Produtos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produto>> Get(Guid id)
        {
            var produto = await _db.Produtos.FirstOrDefaultAsync(x => x.Id == id);

            if (produto == null) 
            {
                return NotFound();
            }
            return Ok(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Produto produto)
        {
            if (produto == null)
            {
                return BadRequest();
            }

            _db.Produtos.Add(produto);
            await _db.SaveChangesAsync();

            string uri = Url.Action("Get", new { id = produto.Id });
            return Created(uri, produto);
        }
    }
}
