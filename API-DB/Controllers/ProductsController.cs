using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_DB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        //Conexion
        private readonly ProductosDBContext _context;

        public ProductsController(ProductosDBContext context)
        {
            _context = context;
        }

        //Leer
        [HttpGet]
        public async Task<ActionResult<List<Producto>>> Get()
        {
            //return Ok(await _context.Productos.ToListAsync());
            return Ok(await _context.Productos.ToListAsync());
        }

        //Leer por id
        [HttpGet("{ProdId}")]
        public async Task<ActionResult<Producto>> Get(int ProdId)
        {
            var producto = await _context.Productos.FindAsync(ProdId);
            if (producto == null)
                return BadRequest("Producto no encontrado");
            return Ok(producto);
        }


        //Crear
        [HttpPost]
        public async Task<ActionResult<List<Producto>>> Post([FromBody] Producto producto)
        {
            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return Ok(await _context.Productos.ToListAsync());
        }


        //Actualizar
        [HttpPut]
        public async Task<ActionResult<List<Producto>>> Update([FromBody] Producto update)
        {

            var dbProducto = await _context.Productos.FindAsync(update.ProdId);
            if (dbProducto == null)
                return BadRequest("Producto no encontrado");

            dbProducto.ProdNom = update.ProdNom;
            dbProducto.ProdDesc = update.ProdDesc;
            dbProducto.CatFk = update.CatFk;

            await _context.SaveChangesAsync();

            return Ok(await _context.Productos.ToListAsync());
        }


        //Eliminar
        [HttpDelete("{ProdId}")]
        public async Task<ActionResult<List<Producto>>> Delete(int ProdId)
        {

            var dbProducto = await _context.Productos.FindAsync(ProdId);
            if (dbProducto == null)
                return BadRequest("Producto no encontrado");

            _context.Productos.Remove(dbProducto);
            await _context.SaveChangesAsync();

            return Ok(await _context.Productos.ToListAsync());
        }
    }
}
