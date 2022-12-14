using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CommunityContentSubmissionPage.Specs.Drivers
{
    public class WebServerDriver
    {
        private IHost _host;

        public WebServerDriver()
        {
            Hostname = $"http://localhost:{GeneratePort()}";
        }

        public string Hostname { get; }

        public void Start()
        {
            string location = typeof(KestrelHostBuilder).Assembly.Location;
            var applicationAssemblyPath = Path.GetDirectoryName(location);

            if (applicationAssemblyPath is null)
                throw new Exception("Location of application assembly could not be found");

            string webRoot = Path.Combine(applicationAssemblyPath, "..", "..", "..", "..",
                "CommunityContentSubmissionPage", "wwwroot");

            var hostBuilder = new KestrelHostBuilder();
            var builder = hostBuilder.CreateHostBuilder(new string[] { }, Hostname, webRoot);
            _host = builder.Build();
            _host.StartAsync().ConfigureAwait(false);
        }


        public async Task Stop()
        {
            if (_host is not null) await _host.StopAsync();
        }

        private int GeneratePort()
        {
            return new Random().Next(5000, 32000);
        }
    }
}
