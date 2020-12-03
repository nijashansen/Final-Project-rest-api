using FinalProject.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectAPI.Data
{
    interface IDBSeeder
    {
        void SeedDB(ErrorContext ctx);
    }
}
