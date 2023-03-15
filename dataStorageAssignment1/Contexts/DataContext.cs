using dataStorage.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace dataStorage.Contexts
{
    internal class DataContext : DbContext
    {
        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\mille\Dropbox\EC-Utbildning\Datalagring\Assignment\Nytt\dataStorageAssignment1\dataStorageAssignment1\Contexts\db_sql_vea01.mdf;Integrated Security=True;Connect Timeout=30";

        #region constructors
        public DataContext()
        {
            
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        #endregion


        #region overrides
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString);
        }
        #endregion



        public DbSet<CustomerEntity> Customers { get; set; } = null!;
        public DbSet<ErrandEntity> Errands { get; set; } = null!;
        public DbSet<ErrandStatusEntity> ErrandStatus { get; set; } = null!;
        public DbSet<CommentEntity> CommentEntity { get; set; } = null!;


    }
}
