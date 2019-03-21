using dmuka2.CS.UnitTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npgsql;
using System;
using System.Linq;

namespace muhonur.TransactionEntity.MSTest
{
    [TestClass]
    public class DbContextTests
    {
        [TestMethod]
        public void InsertTest()
        {
            using (TestDatabase db = TestDatabase.NewInstance())
            {
                db.students.Add(new Models.students()
                {
                    name = "Muhammed"
                });

                db.SaveChanges();
                db.Commit();
            }

            using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(Helper.ConnectionString))
            {
                con.Open();

                var com = new Npgsql.NpgsqlCommand("SELECT * FROM " + nameof(Models.students), con);
                var reader = com.ExecuteReader();
                var isReaded = reader.Read();
                con.Close();

                Assert.IsFalse(isReaded);
            }
        }

        [TestMethod]
        public void UpdateTest()
        {
            using (TestDatabase db = TestDatabase.NewInstance())
            {
                db.students.Add(new Models.students()
                {
                    name = "Muhammed"
                });

                db.SaveChanges();

                var student = db.students.FirstOrDefault();
                student.name = "Ahmet";
                db.SaveChanges();

                db.Commit();
            }

            using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(Helper.ConnectionString))
            {
                con.Open();

                var com = new Npgsql.NpgsqlCommand("SELECT * FROM " + nameof(Models.students), con);
                var reader = com.ExecuteReader();
                var isReaded = reader.Read();

                con.Close();

                Assert.IsFalse(isReaded);
            }
        }

        [TestMethod]
        public void DeleteTest()
        {
            using (TestDatabase db = TestDatabase.NewInstance())
            {
                db.students.Add(new Models.students()
                {
                    name = "Muhammed"
                });

                db.SaveChanges();

                var student = db.students.FirstOrDefault();
                db.students.Remove(student);
                db.SaveChanges();

                db.Commit();
            }

            using (Npgsql.NpgsqlConnection con = new NpgsqlConnection(Helper.ConnectionString))
            {
                con.Open();

                var com = new Npgsql.NpgsqlCommand("SELECT * FROM " + nameof(Models.students), con);
                var reader = com.ExecuteReader();
                var isReaded = reader.Read();
                con.Close();

                Assert.IsFalse(isReaded);
            }
        }
    }
}
