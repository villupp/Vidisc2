using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Vidisc2
{
    public static class Utils
    {
        // Logger instance
        private static ILogger logger;
        public static ILogger Logger
        {
            get
            {
                return logger;
            }
            set
            {
                if (logger != null) { Logger.LogWarning("Logger already initialized."); }
                else logger = value;
            }
        }
    }
}
