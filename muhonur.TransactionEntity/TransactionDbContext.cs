using dmuka2.CS.UnitTest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;

namespace muhonur.TransactionEntity
{
    public abstract class TransactionDbContext<TDbContext> : DbContext where TDbContext : TransactionDbContext<TDbContext>
    {
        #region Variables
        static TDbContext __staticInstance = null;

        IDbContextTransaction _currentTransaction = null;
        #endregion

        #region Constructors
        static TransactionDbContext()
        {
            __staticInstance = NewInstance();
        }
        #endregion

        #region Methods
        public void Commit()
        {
#if RELEASE == false
            if (IsUnitTest.Check)
                return;
#endif

            this._currentTransaction.Commit();
            this._currentTransaction = this.Database.BeginTransaction();
        }

        public void Rollback()
        {
            this._currentTransaction.Rollback();
            this._currentTransaction = this.Database.BeginTransaction();
        }

        public override void Dispose()
        {
#if RELEASE == false
            if (IsUnitTest.Check)
                return;
#endif

            this._currentTransaction.Rollback();
            this._currentTransaction.Dispose();

            base.Dispose();
        }

        public static TDbContext NewInstance()
        {
#if RELEASE == false
            if (IsUnitTest.Check)
            {
                if (__staticInstance != null)
                    return __staticInstance;
            }
#endif

            var instance = (TDbContext)typeof(TDbContext).GetMethod("Create", BindingFlags.Public | BindingFlags.Static).Invoke(null, null);
            instance._currentTransaction = instance.Database.BeginTransaction();

            return instance;
        }
        #endregion
    }
}
