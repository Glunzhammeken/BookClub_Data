using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClub_Data
{
    public class BookClubDbContextSecrets
    {
        public static readonly string ConnectionStringLaptop = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookClubDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
    }
}
