using Zeexone.Framework.Windows.Framework;

namespace PST.Plugins.WDSDispatcher
{
    public class WDSDispatcherPluginContext : PluginContextBase
    {
        private static readonly WDSDispatcherPluginContext _instance = new WDSDispatcherPluginContext();

        private WDSDispatcherPluginContext()
        {
        }

        public static WDSDispatcherPluginContext S
        {
            get { return _instance; }
        }
    }
}
