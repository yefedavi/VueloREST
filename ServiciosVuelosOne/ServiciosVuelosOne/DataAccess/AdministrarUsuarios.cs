using ServiciosVuelosOne.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServiciosVuelosOne.DataAccess
{
    public class AdministrarUsuarios : IAdministrarUsuarios
    {
        public ReservaVuelosEntities vuelosContext { get; set; }

        public AdministrarUsuarios()
        {
            vuelosContext = new ReservaVuelosEntities();
        }
        /// <summary>
        /// Mètodo encargado de crear un usuario e insertarlo en la base de datos
        /// </summary>
        /// <param name="usuario"></param>
        public Boolean CrearUsuario(Usuario usuario)
        {

            vuelosContext.Usuario.Add(usuario);
            vuelosContext.SaveChanges();
            return true;
        }
        /// <summary>
        /// Mètodo encargado de consultar un usuario atravès del username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Usuario registrado en la base de datos</returns>
        public Usuario ConsultarUsuario(string username)
        {
            var usuarios = from u in vuelosContext.Usuario
                           where u.Username == username
                           select u;
            return usuarios.First();
        }
        /// <summary>
        /// Mètodo encargado de validar el usuario para ingresar a la aplicaciòn
        /// </summary>
        /// <param name="username"></param>
        /// <param name="contraseña"></param>
        /// <returns>true si el ingreso es exitoso,de lo contrario false</returns>
        public bool LoguearUsuario(string username, string contraseña)
        {
            Boolean ingresoExitoso = false;
            vuelosContext = new ReservaVuelosEntities();
            var usuario = from u in vuelosContext.Usuario
                          where u.Username == username &&
                          u.Password == contraseña
                          select u;
            if (usuario.FirstOrDefault() != null && usuario.FirstOrDefault() != default(Usuario))
            {
                ingresoExitoso = true;
            }
            return ingresoExitoso;
        }
        /// <summary>
        /// Mètodo encargado de obtener todos los usuarios registrados en la aplicaciòn
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        public List<Usuario> GetAllUsuarios()
        {
            var usuarios = from u in vuelosContext.Usuario
                           select u;
            return usuarios.ToList();
        }

        /// <summary>
        /// Mètodo encargado de validar si el usuario es mayor de edad
        /// </summary>
        /// <param name="username"></param>
        /// <returns>true si es mayor de edad,de lo contrario retorna false</returns>
        public Boolean EsMayorDeEdad(String username)
        {
            Boolean isMayorEdad = false;
            var queryUser = from u in vuelosContext.Usuario
                          where u.Username == username
                          select u.FechaNacimiento;
            DateTime fechaNacimientoUsuario = queryUser.First();

            //Consulto la fecha de nacimiento y valido
            DateTime fechaActual = DateTime.Today;
            int YearsDifference = fechaActual.Year - fechaNacimientoUsuario.Year;

            if (YearsDifference >= 18)
            {
                isMayorEdad = true;
            }

            return isMayorEdad;
        }
    }
}