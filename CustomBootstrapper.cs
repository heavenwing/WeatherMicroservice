using Nancy;
using Nancy.Bootstrapper;
using Nancy.Configuration;
using Nancy.Diagnostics;
using Nancy.TinyIoc;

namespace WeatherMicroservice
{
    public class CustomBootstrapper : DefaultNancyBootstrapper
    {
        public override void Configure(INancyEnvironment environment)
        {
            environment.Tracing(true, true);
        }

        // protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        // {
        //     DiagnosticsHook.Disable(pipelines);
        // }
    }
}