using System;
using System.Collections.Generic;
using System.Text;

namespace dmuka2.CS.UnitTest
{
    /// <summary>
    /// This code is doing only that check RELEASE is active.
    /// <para></para>
    /// So your unit test never work on RELEASE.
    /// <para></para>
    /// Thus your special codes that is for only unit test never crash.
    /// <para></para>
    /// It means that you should use this class for each your unit tests class.
    /// </summary>
    public class BaseUnitTest
    {
        #region Constructors
        public BaseUnitTest()
        {
#if RELEASE == true
            throw new Exception("UnitTests couldn't be run on RELEASE!");
#endif
        }
        #endregion
    }
}
