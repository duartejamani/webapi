using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi2.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace webapi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {


        private readonly DataContext _dataContext;

        public ClienteController(DataContext context)
        {
            _dataContext = context;
        }
        [HttpGet]

        public async Task<ActionResult<List<Cliente>>> GetAll()
        {
            return Ok(await _dataContext.newCliente.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Cliente>>> GetbyId(int id)
        {
            var cliente = await _dataContext.newCliente.FindAsync(id);
            return Ok(cliente);

            //return Ok(await _dataContext.newCliente.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Cliente>>> Post(Cliente cliente)
        {
            _dataContext.newCliente.Add(cliente);
            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.newCliente.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Cliente>>> Put(Cliente request)
        {
            var cliente = await  _dataContext.newCliente.FindAsync(request.id);
            if (cliente == null)
                return BadRequest("cliente not found. ");
            cliente.nombre = request.nombre;
            cliente.correo = request.correo;
            cliente.password = request.password;

            return Ok(cliente);

        }



    }
}
