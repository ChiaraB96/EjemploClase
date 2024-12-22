using System.ComponentModel.DataAnnotations;
using EjemploClase.Model;
using EjemploClase.QueryResponse;
using EjemploClase.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Matching;

namespace EjemploClase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NorthwindController : ControllerBase
    {
        private INorthwindRepository _repository;

        public NorthwindController(INorthwindRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("api/TodosLosEmpleados")]
        public async Task<List<Employees>> ObtenerTodosLosEmpleados()
        {
            return  await _repository.ObtenerTodosLosEmpleados();
        }
        [HttpGet]
        [Route("api/CantidadEmpleados")]
        public async Task<int> ObtenerCantidadTodosLosEmpleados()
        {
            return await _repository.ObtenerCantidadTodosLosEmpleados();
        }

        [HttpGet]
        [Route("api/EmpleadoPorID")]
        public async Task<Employees> ObtenerEmpleadoPorID([FromQuery] int empleadoID)
        {
            return await _repository.ObtenerEmpleadoPorID(empleadoID);
        }

        [HttpGet]
        [Route("api/EmpleadoPorNombre")]
        public async Task<Employees> ObtenerEmpleadosPorNombre([FromQuery] string empleadoNombre)
        {
            return await _repository.ObtenerEmpleadosPorNombre(empleadoNombre);
        }
        
        [HttpGet]
        [Route("api/IDEmpleadoPorTitulo")]
        public async Task<Employees> ObtenerIDporTitulo([FromQuery] string titulo)
        {
            return await _repository.ObtenerIDporTitulo(titulo);
        }
        
        [HttpGet]
        [Route("api/EmpleadoPorPais")]
        public async Task<Employees> ObtenerIEmpleadoPorPais([FromQuery] string country)
        {
            return await _repository.ObtenerIEmpleadoPorPais(country);
        }
        
        [HttpGet]
        [Route("api/TodosEmpleadosPorPais")]
        public async Task<List<Employees>> ObtenerTodosLosEmpleadosPorPais([FromQuery] string country)
        {
            return await _repository.ObtenerTodosLosEmpleadosPorPais(country);
        }

        [HttpGet]
        [Route("api/EmpleadoMayor")]
        public async Task<Employees> ObtenerEmpleadoGrande()
        {
            return await _repository.ObtenerEmpleadoGrande();
        }

        [HttpGet]
        [Route("api/CantEmpleadosPorTitulo")]
        public async Task<List<EmpleadosPorTituloResponse>> ObtenerCantEmpleadosPorTitulo()
        {
            return await _repository.ObtenerCantEmpleadosPorTitulo();
        }

        [HttpGet]
        [Route("api/ProductosPorCategoria")]
        public async Task<List<ProductoPorCatResponse>> ObtenerProductosPorCategoria()
        {
            return await _repository.ObtenerProductosPorCategoria();
        }

        [HttpGet]
        [Route("api/ProductoQueContiene")]
        public async Task<List<Products>> ObtenerProductosQueContienen(String palabra)
        {
            return await _repository.ObtenerProductosQueContienen(palabra);
        }

        [HttpDelete]
        [Route("api/EliminarOrdenPorID")]
        public async Task<bool> EliminarOrdenPorID([Required, FromQuery] int id)
        {
            return await _repository.EliminarOrdenPorID(id);
        }

        [HttpPut]
        [Route("api/ModificarNombreEmpleado")]
        public async Task<bool> ModificarNombreEmpleado([Required, FromQuery] int id, [Required, FromQuery] string nombre)
        {
            return await _repository.ModificarNombreEmpleado(id, nombre);
        }

        [HttpPut]
        [Route("api/InsertarEmpleado")]
        public async Task<bool> InsertarEmpleado()
        {
            return await _repository.InsertarEmpleado();
        }

    }
}
