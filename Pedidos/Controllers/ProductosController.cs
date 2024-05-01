using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pedidos.Context;
using Dominio.Entities;
using Dominio.Dtos;
using Dominio;
using AutoMapper;

namespace Productos.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {

        private readonly DbContexto _context;
        private readonly IMapper _mapper;


        public ProductosController(DbContexto context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult Crear([FromBody] CrearProductoDto crearProductoDto)
        {

           var producto = _mapper.Map<Producto>(crearProductoDto); 

            //Mapeo Manual

            //Dto - Entidad
           

            producto.Estado = "Registrado";
            producto.FechaRegistro = DateTime.Now;
            producto.Codigo = producto.Categoria.Substring(0, 1) + new Random().NextInt64(1, 10000);
            _context.Productos.Add(producto);
            _context.SaveChanges();

            //Entidad - Dto
           var productoCreadoDto = _mapper.Map<ProductoCreadoDto>(producto);


            return Ok(productoCreadoDto);

        }

       [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

           var productoEncontrado = _context.Productos.Find(id);

            if (productoEncontrado is not null)
                {
                _context.Remove(productoEncontrado);
                _context.SaveChanges();

              return Ok();
            }


           return NotFound();

        }

    }
}
