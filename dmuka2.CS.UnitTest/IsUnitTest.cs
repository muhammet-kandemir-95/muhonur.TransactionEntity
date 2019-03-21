using System;
using System.Linq;

namespace dmuka2.CS.UnitTest
{
    // This code is never compiled by compiler on RELEASE. 
    // Because it is unnecessary.
#if RELASE == false
    /// <summary>
    /// We are checking that unit test is active via this class.
    /// </summary>
    public static class IsUnitTest
    {
        #region Variables
        /// <summary>
        /// If this value is check, it means that unit test is enable.
        /// <para></para>
        /// If you write some code with checking that unit test's state, you can know using this variable.
        /// </summary>
        public static bool Check { get; private set; }

        /// <summary>
        /// If you have to use some objects only for unit tests, you should use this variable.
        /// </summary>
        public static dynamic TestObjects { get; set; }
        #endregion

        #region Constructors
        static IsUnitTest()
        {
            Check = AppDomain.CurrentDomain.GetAssemblies().Any(o =>
            {
                var toLower = o.FullName.ToLowerInvariant();
                // If application assemblies have any library in below list, it means that unit test is enable.
                return
                    toLower.Contains("mstest") ||
                    toLower.Contains("nunit") ||
                    toLower.Contains("xunit");
            });
        }
        #endregion
    }
#endif
}
