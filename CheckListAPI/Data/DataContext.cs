using CheckListAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CheckListAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<CheckListHeader> CheckListHeader => Set<CheckListHeader>();
        public DbSet<CheckListItens> CheckListsItens => Set<CheckListItens>();
        public DbSet<CheckListOwner> CheckListOwner => Set<CheckListOwner>();
        public DbSet<CheckListVehicles> CheckListVehicles => Set<CheckListVehicles>();
        public DbSet<CheckListItemGroup> CheckListItemGroup => Set<CheckListItemGroup>();
        public DbSet<CheckListSupervisor> CheckListSupervisor => Set<CheckListSupervisor>();
        public DbSet<CheckListItensVehicle> CheckListItensVehicle => Set<CheckListItensVehicle>();
        public DbSet<Users> Users => Set<Users>();

        //public DbSet<Auth> Auth => Set<Auth>();
    }
}
