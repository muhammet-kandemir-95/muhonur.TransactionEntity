using System;
using System.Collections.Generic;
using System.Text;

namespace muhonur.TransactionEntity.MSTest
{
    public static class Helper
    {
        /// <summary>
        /// You have to install postgres to use this connection string.
        /// <para></para>
        /// After that, you can use this connection string on tests.
        /// </summary>
        public static readonly string ConnectionString = "User ID=postgres;Password=1;Host=localhost;Port=5432;Database=Test;";
    }
}
