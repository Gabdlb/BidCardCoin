using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp11
{
    class MetierORM
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMetier"></param>
        /// <returns></returns>
        public static MetierViewModel getMetier(int idMetier)
        {
            MetierDAO m = MetierDAO.getMetier(idMetier);
            MetierViewModel metier = new MetierViewModel(m.idMetierDAO, m.libMetierDAO);
            return metier;
        }
        public static void updateMetier(MetierViewModel p)
        {
            MetierDAO.updateMetier(new MetierDAO(p.idMetier, p.libMetier));
        }

    }
}
