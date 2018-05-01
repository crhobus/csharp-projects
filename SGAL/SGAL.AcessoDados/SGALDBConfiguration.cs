using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGAL.AcessoDados
{
    public class SGALDBConfiguration : DbConfiguration
    {
        public SGALDBConfiguration()
        {
            SetProviderServices(
                   SqlProviderServices.ProviderInvariantName,
                   SqlProviderServices.Instance);
        }
    }
}
