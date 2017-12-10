using GlenwoodMed.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlenwoodMed.BusinessLogic.Business
{
    public static class InitializeBusiness
    {
        public static void Initilize()
        {
            Database.SetInitializer<DataContext>(new DbInitialize<DataContext>());
            var ctx = new DataContext();
            ctx.Database.Initialize(true);
        }

    }
}
