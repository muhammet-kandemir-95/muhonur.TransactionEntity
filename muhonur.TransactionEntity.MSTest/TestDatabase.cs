using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace muhonur.TransactionEntity.MSTest
{
    #region Models
    namespace Models
    {
        [Table("students")]
        public class students
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
            public long student_id { get; set; }

            [Required]
            [StringLength(50)]
            public string name { get; set; }
        }
    }
    #endregion

    public class TestDatabase : TransactionDbContext<TestDatabase>
    {
        #region Variables
        public DbSet<Models.students> students { get; set; }
        #endregion

        #region Constructors
        private TestDatabase() { }
        #endregion

        #region Methods
        public static TestDatabase Create()
        {
            return new TestDatabase();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(Helper.ConnectionString);
        }
        #endregion
    }
}
