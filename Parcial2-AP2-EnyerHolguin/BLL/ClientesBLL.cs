using Microsoft.EntityFrameworkCore;
using Parcial2_AP2_EnyerHolguin.DAL;
using Parcial2_AP2_EnyerHolguin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Parcial2_AP2_EnyerHolguin.BLL
{
    public class ClientesBLL
    {
         private Contexto _contexto { get; set; }

        public ClientesBLL(Contexto contexto)
        {
            this._contexto = contexto;
        }

        public async Task<List<Clientes>> GetList(Expression<Func<Clientes, bool>> criterio)
        {
            List<Clientes> lista = new List<Clientes>();

            try
            {
                lista = await _contexto.Cliente.Where(criterio).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return lista;
        }
    }
}
