using Dominio.Dtos;
using Dominio.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pedidos;
using Pedidos.Context;

namespace Vehiculos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {

        private readonly DbContexto _context;


        public VehiculoController(DbContexto context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Vehiculo>> Get()
        {

            return _context.Vehiculos.ToList();

        }

        [HttpPost]
        public ActionResult Crear([FromBody] CrearVehiculoDto crearVehiculoDto)
        {

            Vehiculo vehiculo = new Vehiculo();

            //Mapeo Manual

            //Dto - Entidad
            vehiculo.Marca = crearVehiculoDto.Marca;
            vehiculo.Modelo = crearVehiculoDto.Modelo;
            vehiculo.Matricula = crearVehiculoDto.Matricula;
            
            vehiculo.FechaRegistro = DateTime.Now;
            _context.Vehiculos.Add(vehiculo);
            _context.SaveChanges();

            //Entidad - Dto
            VehiculoCreadoDto vehiculoCreadoDto = new VehiculoCreadoDto();
            vehiculoCreadoDto.Id = vehiculo.Id;
            vehiculoCreadoDto.Matricula = vehiculo.Matricula ;
            vehiculoCreadoDto.Marca = vehiculo.Marca ;
            vehiculoCreadoDto.Modelo = vehiculo.Modelo;


            return Ok(vehiculoCreadoDto);

        }
    }
}

