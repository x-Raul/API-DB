using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_DB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        //Conexion
        private readonly ProductosDBContext _context;

        public CategoryController(ProductosDBContext context)
        {
            _context = context;
        }

        //Leer
        [HttpGet]
        public async Task<ActionResult<List<Categorium>>> Get()
        {
            //return Ok(await _context.Categoria.ToListAsync());
            return Ok(await _context.Categoria.ToListAsync());
        }

        //Leer por id
        [HttpGet("{CatId}")]
        public async Task<ActionResult<Categorium>> Get(int CatId)
        {
            var categoria = await _context.Categoria.FindAsync(CatId);
            if (categoria == null)
                return BadRequest("Producto no encontrado");
            return Ok(categoria);
        }


        //Crear
        [HttpPost]
        public async Task<ActionResult<List<Categorium>>> Post([FromBody] Categorium categoria)
        {
            _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();

            return Ok(await _context.Categoria.ToListAsync());
        }


        //Actualizar
        [HttpPut]
        public async Task<ActionResult<List<Categorium>>> Update([FromBody] Categorium update)
        {

            var dbCategoria = await _context.Categoria.FindAsync(update.CatId);
            if (dbCategoria == null)
                return BadRequest("Producto no encontrado");
        
            dbCategoria.CatNom = update.CatNom;
            dbCategoria.CatDesc = update.CatDesc;
            

            await _context.SaveChangesAsync();

            return Ok(await _context.Categoria.ToListAsync());
        }


        //Eliminar
        [HttpDelete("{CatId}")]
        public async Task<ActionResult<List<Categorium>>> Delete(int CatId)
        {

            var dbCategoria = await _context.Categoria.FindAsync(CatId);
            if (dbCategoria == null)
                return BadRequest("Producto no encontrado");

            _context.Categoria.Remove(dbCategoria);
            await _context.SaveChangesAsync();

            return Ok(await _context.Categoria.ToListAsync());
        }
    }
}
