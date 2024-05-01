using Dominio.Dtos;
using Dominio.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pedidos.Context;

namespace Pedidos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConductorController : ControllerBase
    {

        private readonly DbContexto _context;


        public ConductorController(DbContexto context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Conductor>> Get()
        {

            return _context.Conductors.ToList();

        }

        [HttpPost]
        public ActionResult Crear([FromBody] CrearConductorDto crearConductorDto)
        {

            Conductor conductor = new Conductor();

            //Mapeo Manual

            //Dto - Entidad
            conductor.Nombres = crearConductorDto.Nombres;
            conductor.Apellidos = crearConductorDto.Apellidos;
            conductor.Licenciatransito = crearConductorDto.LicenciaTrasito;


            conductor.FechaRegistro = DateTime.Now;
            _context.Conductors.Add(conductor);
            _context.SaveChanges();

            //Entidad - Dto
            ConductorCreadoDto conductorCreadoDto = new ConductorCreadoDto();
            conductorCreadoDto.Id = conductor.Id;
            conductorCreadoDto.Nombres = conductor.Nombres;
            conductorCreadoDto.Apellidos = conductor.Apellidos;
            conductorCreadoDto.Licenciatransito = conductor.Licenciatransito;
            conductorCreadoDto.Fechanacimiento = conductor.Fechanacimiento;



            return Ok(conductorCreadoDto);
        }
}   }
