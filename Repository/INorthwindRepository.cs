using EjemploClase.Model;
using EjemploClase.QueryResponse;

namespace EjemploClase.Repository
{
    public interface INorthwindRepository
    {
        Task<List<Employees>> ObtenerTodosLosEmpleados();
        Task<int> ObtenerCantidadTodosLosEmpleados();
        Task<Employees> ObtenerEmpleadoPorID(int id);
        Task<Employees> ObtenerEmpleadosPorNombre(string nombreEmpleado);
        Task<Employees> ObtenerIDporTitulo(string titulo);
        Task<Employees> ObtenerIEmpleadoPorPais(string country);
        Task<List<Employees>> ObtenerTodosLosEmpleadosPorPais(string country);
        Task<Employees> ObtenerEmpleadoGrande();
        Task<List<EmpleadosPorTituloResponse>> ObtenerCantEmpleadosPorTitulo();
        Task<List<ProductoPorCatResponse>> ObtenerProductosPorCategoria();
        Task<List<Products>> ObtenerProductosQueContienen(String palabra);
        Task<bool> EliminarOrdenPorID(int id);
        Task<bool> ModificarNombreEmpleado(int idEmpleado, string nombre);
        Task<bool> InsertarEmpleado();
    }
}
