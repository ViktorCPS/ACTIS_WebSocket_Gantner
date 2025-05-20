using Microsoft.EntityFrameworkCore;

namespace ACTIS_WebSocket_Gantner.Data
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }
    }
}
