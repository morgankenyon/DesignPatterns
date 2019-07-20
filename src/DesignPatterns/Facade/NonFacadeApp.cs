using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPatterns.Facade
{
    public class NonFacadeApp
    {
        public bool IsDatabaseAHealthy()
        {
            //perform checks
            return true;
        }

        public bool IsDatabaseBHealthy()
        {
            //perform checks
            return true;
        }

        public bool IsServiceAHealthy()
        {
            //perform checks
            return true;
        }

        public bool IsServiceBHealthy()
        {
            //perform checks
            return true;
        }
    }
}
