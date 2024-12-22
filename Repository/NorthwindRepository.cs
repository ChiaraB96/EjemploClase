using EjemploClase.DataContext;
using EjemploClase.Model;
using EjemploClase.QueryResponse;
using Microsoft.EntityFrameworkCore;

namespace EjemploClase.Repository
{
    public class NorthwindRepository : INorthwindRepository
    {
        private readonly DataContextNorthwind _dataContext;

        public NorthwindRepository(DataContextNorthwind dataContext) 
        {
            _dataContext = dataContext;
        
        }
        public async Task<List<Employees>> ObtenerTodosLosEmpleados() 
        { 
            var result = await _dataContext.Employees.ToListAsync();
            return result;
        }

        public async Task<int> ObtenerCantidadTodosLosEmpleados()
        {
            var result = await _dataContext.Employees.CountAsync();
            return result;
        }

        public async Task<Employees> ObtenerEmpleadoPorID( int id)
        {
            var result = await _dataContext.Employees.Where(e => e.EmployeeID == id).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Employees> ObtenerEmpleadosPorNombre(string nombreEmpleado)
        {
            var result = await _dataContext.Employees.FirstOrDefaultAsync(e => e.FirstName ==nombreEmpleado);
            return result;
        }

        public async Task<Employees> ObtenerIDporTitulo(string titulo)
        {
            var result = from emp in _dataContext.Employees where emp.Title == titulo select emp;
            return await result.FirstOrDefaultAsync();
        }
        public async Task<Employees> ObtenerIEmpleadoPorPais(string country)
        {
            var result = from emp in _dataContext.Employees
                         where emp.Country == country
                         select new Employees
                         {
                             Title = emp.Title,
                             FirstName = emp.FirstName,

                         };
            return await result.FirstOrDefaultAsync();
        }
        public async Task<List<Employees>> ObtenerTodosLosEmpleadosPorPais(string country)
        {
            var result = from emp in _dataContext.Employees
                         where emp.Country == country
                         orderby emp.FirstName
                         select new Employees
                         {
                             Title = emp.Title,
                             FirstName = emp.FirstName,
                         };
            return await result.ToListAsync();
        }

        public async Task<Employees> ObtenerEmpleadoGrande()
        {
            var result = from emp in _dataContext.Employees
                         orderby emp.DateBirth
                         select new Employees
                         {
                             Title = emp.Title,
                             FirstName = emp.FirstName,
                             LastName = emp.LastName,
                         };
            return await result.FirstOrDefaultAsync();
        }
        public async Task<List<EmpleadosPorTituloResponse>> ObtenerCantEmpleadosPorTitulo()
        {
            var result = await (from emp in _dataContext.Employees
                                group emp by emp.Title into g
                                select new EmpleadosPorTituloResponse
                                {
                                    Titulo = g.Key,
                                    CantidadEmpleados = g.Count()
                                }).ToListAsync();
            return result;
        }

        public async Task<List<ProductoPorCatResponse>> ObtenerProductosPorCategoria()
        {
            var result = from prod in _dataContext.Products
                         join cat in _dataContext.Categories on prod.CategoryID equals cat.CategoryID
                         select new ProductoPorCatResponse
                         {
                             Producto = prod.ProductName,
                             Categoria = cat.CategoryName
                         };
            return await result.ToListAsync();
        }

        public async Task<List<Products>> ObtenerProductosQueContienen(String palabra)
        {
            var result = await _dataContext.Products.Where(p => p.ProductName.Contains(palabra)).ToListAsync();
            return result;
        }

        public async Task<bool> EliminarOrdenPorID(int OrderID)
        {
            Orders? orden = await _dataContext.Orders.Where(r => r.OrderID == OrderID).FirstOrDefaultAsync();
            OrderDetails? ordenDetail = await _dataContext.OrderDetails.Where(r => r.OrderID == orden.OrderID).FirstOrDefaultAsync();

            _dataContext.OrderDetails.Remove(ordenDetail);
            _dataContext.Orders.Remove(orden);

            var resulta = _dataContext.SaveChanges();
            return true;
        }

        public async Task<bool> ModificarNombreEmpleado(int idEmpleado, string nombre)
        {
            bool actualizado = false;
            Employees result = await _dataContext.Employees.Where(r => r.EmployeeID == idEmpleado).FirstOrDefaultAsync();

            if (result == null)
            {
                result.FirstName = nombre;
                var resulta = _dataContext.SaveChanges();
                actualizado = true;
            }

            return actualizado;
        }

        public async Task<bool> InsertarEmpleado()
        {
            Employees employee = new Employees();
            employee.Title = "Sales Manager";
            employee.City = "Rosario";
            employee.FirstName = "Chiara";
            employee.LastName = "Borgatti";
            employee.HireDate = DateTime.Now;
            employee.DateBirth = DateTime.Now;
            var newEmploee = await _dataContext.AddAsync(employee);
            var result = _dataContext.SaveChanges();

            return (result > 0);
        }
    }
}
