﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using Dominio; //se referencia el proyecto

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();

            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
            

            try
            {
                conexion.ConnectionString = "Data Source = .; Initial Catalog=CATALOGO_DB; integrated security=true";
               
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT * FROM ARTICULOS ";
                comando.Connection = conexion;
                
                conexion.Open();
                lector = comando.ExecuteReader();
                
                while (lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)lector["Id"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Codigo = (string)lector["Codigo"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.IdMarca = (int)lector["IdMarca"];
                    aux.IdCategoria = (int)lector["IdCategoria"];
                    aux.ImagenUrl = (string)lector["ImagenURL"];
                    aux.Precio = (decimal)lector["Precio"];



                    lista.Add(aux);
                    

                }


                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            
        }
    }
}
