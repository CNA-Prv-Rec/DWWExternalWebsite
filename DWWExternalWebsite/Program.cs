using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.Extensions.Logging.ApplicationInsights;


namespace DWWExternalWebsite
{
    public class Program
    {   
      //  static InMemoryChannel channel = new InMemoryChannel();
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Configuration.AddEnvironmentVariables();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();
            AppDomain.CurrentDomain.ProcessExit += (sender, e) => { FinalizeApplication(serviceProvider); };
            

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddEndpointsApiExplorer();
            
        
          
            builder.Logging.AddApplicationInsights();
         
            builder.Logging.AddApplicationInsights(configureTelemetryConfiguration: (config) =>
               
                config.ConnectionString = Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING")
                
               , configureApplicationInsightsLoggerOptions: (options) => { }
            ) ;
            

        

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

      
            app.Run();
           
        //   channel.Flush();
        }
  
        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            var telemetryConfiguration = TelemetryConfiguration.CreateDefault();
            telemetryConfiguration.ConnectionString = Environment.GetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING");
          //  telemetryConfiguration.InstrumentationKey = Environment.GetEnvironmentVariable("APPINSIGHTS_INSTRUMENTATIONKEY");
            var telemetryClient = new TelemetryClient(telemetryConfiguration);
            serviceCollection.AddSingleton(telemetryClient);
        }
    
        private static void FinalizeApplication(ServiceProvider serviceProvider)
        {
            var client = serviceProvider.GetService<TelemetryClient>();
           client.Flush();
            Thread.Sleep(5000);
        }

    }
}