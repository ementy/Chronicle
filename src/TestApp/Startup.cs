using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Chronicle;

namespace TestApp
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<ISagaStartAction<Message1>, SampleSaga>();
            //services.AddTransient<ISagaAction<Message2>, SampleSaga>();
            services.AddChronicle();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var coordinator = app.ApplicationServices.GetService<ISagaCoordinator>();

            var id = Guid.NewGuid();

            coordinator.ProcessAsync(id, new Message1
            {
                Text = "This message will be used one day..."
            });

            coordinator.ProcessAsync(id, new Message2
            {
                Text = "But this one will be printed first! (We compensate from the end to beggining of the log)"
            });

            Console.ReadLine();
        }
    }
}
