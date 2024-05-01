using AutoMapper;
using Dominio.Dtos;
using Dominio.Entities;

namespace Pedidos.Mapeos
{
    public class AutoMaperPerfil : Profile
    {
        public AutoMaperPerfil()
        {
            CreateMap<CrearProductoDto, Producto>();
            //_mapper.Map<Producto>(crearProductoDto)
            CreateMap<Producto, ProductoCreadoDto>();
            //_mapper.Map<ProductoCreadoDto>(producto)
        }
    }
}
