using Restaurant.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restaurant.Util
{
    public static class UtillClass
    {
        public static StartAutoFac StartInterface()
        {
            StartAutoFac app = new StartAutoFac();
            app.OnStartup();
            return app;
        }
    }
}