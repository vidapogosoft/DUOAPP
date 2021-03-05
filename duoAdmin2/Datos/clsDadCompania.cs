using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModeloDatos;
using System.Data.Entity;


namespace Datos
{
    public class clsDadCompania
    {
        public List<adcompania> Get(adcompania toFilter = null)
        {
            using (EncuestaEntities ctx = new EncuestaEntities())
            {

                IQueryable<adcompania> query = ctx.adcompania;

                if (toFilter != null)
                {
                    if (toFilter.ciCompania != 0)
                        query = query.Where(a => a.ciCompania == toFilter.ciCompania);

                    if (!string.IsNullOrEmpty(toFilter.ciEstado))
                        query = query.Where(a => a.ciEstado == toFilter.ciEstado);

                }

                return query.AsNoTracking().ToList();
            }
        }
    }
}
