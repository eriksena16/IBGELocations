using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocationWebApi.IBGE.IBGERepository
{
    class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
           : base(options)
        {
        }
    }
}
