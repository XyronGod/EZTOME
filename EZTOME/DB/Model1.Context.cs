//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EZTOME.DB
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class NetHammerEntities : DbContext
    {
        public NetHammerEntities()
            : base("name=NetHammerEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Employers> Employers { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<StatusProject> StatusProject { get; set; }
        public virtual DbSet<StatusWork> StatusWork { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<Work> Work { get; set; }
    }
}
