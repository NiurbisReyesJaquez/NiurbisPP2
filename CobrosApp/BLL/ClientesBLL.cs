using CobrosApp.DAL;
using CobrosApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CobrosApp.BLL
{
    public class ClientesBLL
    {
        public static List<Clientes> GetClientes()
        {
            Contexto contexto = new Contexto();
            List<Clientes> clientes = new List<Clientes>();
            try
            {
                clientes = contexto.Clientes.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return clientes;
        }
    }
}
