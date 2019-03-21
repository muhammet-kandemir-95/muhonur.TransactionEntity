using dmuka2.CS.UnitTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Npgsql;
using System;

namespace muhonur.TransactionEntity.MSTest
{
    [TestClass]
    public class DatabaseCheckTests : BaseUnitTest
    {
        [TestMethod]
        public void ConnectionTest()
        {
            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(Helper.ConnectionString))
                {
                    con.Open();
                    con.Close();
                }
            }
            catch
            {
                Assert.Fail("You haven't installed postgres on your os!");
            }
        }
    }
}
