using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Mapper.Infrastructure;

namespace BAL.Common
{
    public static class MapperManager
    {
        public static void InitMapper()
        {
            AutoMapperProfile.Run();
        }
    }
}
