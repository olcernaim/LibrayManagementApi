using LibrayManagementApi.Common.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrayManagementApi.Data
{
    public class LibManagementContext : DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public LibManagementContext(DbContextOptions<LibManagementContext> options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {

        }

        DbSet<BOOK> BOOK { get; set; }
        DbSet<AUTHOR> AUTHOR { get; set; }
        DbSet<CATEGORY> CATEGORY { get; set; }
        
        //DbSet<BORROWING> BORROWING { get; set; }
        //DbSet<CATEGORY> CATEGORY { get; set; }
        //DbSet<PUBLISHER> PUBLISHER { get; set; }
        //DbSet<PUNISHMENT> PUNISHMENT { get; set; }
        //DbSet<USERS> USERS { get; set; }
    }
}
