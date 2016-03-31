using System.IO;
using Microsoft.AspNet.FileProviders;
using Microsoft.AspNet.StaticFiles;
using Microsoft.Extensions.PlatformAbstractions;

namespace Microsoft.AspNet.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app, IApplicationEnvironment env)
        {

            var path = Path.Combine(env.ApplicationBasePath, "node_modules");
            var provider = new PhysicalFileProvider(path);

            var options = new StaticFileOptions
            {
                RequestPath = "/node_modules",
                FileProvider = provider
            };

            app.UseStaticFiles(options);

            return app;
        }
    }
}
