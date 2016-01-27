using ServiciosVuelosOne.Models;
using System;
using System.Collections.Generic;

namespace ServiciosVuelosOne.DataAccess
{
    public interface IAdministrarUsuarios
    {
        /// <summary>
        /// Mètodo encargado de crear un usuario e insertarlo en la base de datos
        /// </summary>
        /// <param name="usuario"></param>
        Boolean CrearUsuario(Usuario usuario);
        /// <summary>
        /// Mètodo encargado de consultar un usuario atravès del username
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Usuario registrado en la base de datos</returns>
        Usuario ConsultarUsuario(String username);
        /// <summary>
        /// Mètodo encargado de validar el usuario para ingresar a la aplicaciòn
        /// </summary>
        /// <param name="username"></param>
        /// <param name="contraseña"></param>
        /// <returns>true si el ingreso es exitoso,de lo contrario false</returns>
        Boolean LoguearUsuario(String username, String contraseña);
        /// <summary>
        /// Mètodo encargado de obtener todos los usuarios registrados en la aplicaciòn
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        List<Usuario> GetAllUsuarios();

        /// <summary>
        /// Mètodo encargado de validar si el usuario es mayor de edad
        /// </summary>
        /// <param name="username"></param>
        /// <returns>true si es mayor de edad,de lo contrario retorna false</returns>
        Boolean EsMayorDeEdad(String username);
    }
}
