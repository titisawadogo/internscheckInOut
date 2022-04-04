using System;
using internscheckInOut.Models;
using Microsoft.EntityFrameworkCore;

namespace internscheckInOut.Data
{
	public class CheckInOutDbContext: DbContext
	{
		public CheckInOutDbContext(DbContextOptions options) : base(options)
		{
		}

        //Dbset
        public DbSet<CheckInOut> CheckInOuts { get; set; }
	}
}

