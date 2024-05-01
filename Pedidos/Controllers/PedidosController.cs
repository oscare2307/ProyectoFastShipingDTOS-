using Dominio.Dtos;
using Dominio.Entities;
using Microsoft.AspNetCore.Mvc;
using Pedidos.Context;

namespace Pedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {

        private readonly DbContexto _context;


        public PedidosController(DbContexto context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Pedido>> Get()
        {

            return _context.Pedidos.ToList();

        }

        [HttpPost]
        public ActionResult Crear([FromBody] CrearPedidoDto crearPedidoDto)
        {

            Pedido pedido = new Pedido();

            //Mapeo Manual

            //Dto - Entidad
            pedido.Descripcion = crearPedidoDto.Descripcion;
            pedido.Productos = crearPedidoDto.Productos;
            pedido.direccionRecogida = crearPedidoDto.direccionRecogida;
            pedido.direccionEnvio = crearPedidoDto.direccionEnvio;

            pedido.estadoPedido = "Registrado";
            pedido.FechaRegistro = DateTime.Now;
            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            //Entidad - Dto
            PedidoCreadoDto pedidoCreadoDto = new PedidoCreadoDto();
            pedidoCreadoDto.Id = pedido.Id;
            pedidoCreadoDto.Descripcion = pedido.Descripcion;
            pedidoCreadoDto.direccionRecogida = pedido.direccionRecogida;
            pedidoCreadoDto.direccionEnvio = pedido.direccionEnvio;
            pedidoCreadoDto.estadoPedido = pedido.estadoPedido;


            return Ok(pedidoCreadoDto);

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {


            var pedidoEncontrado = _context.Pedidos.Find(id);

            if (pedidoEncontrado is not null)
            {
                _context.Remove(pedidoEncontrado);
                _context.SaveChanges();

                return Ok();
            }


            return NotFound();

        }

    }
}


