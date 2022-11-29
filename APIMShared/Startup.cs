using APIMShared.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace APIMShared
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //services.AddControllers().AddNewtonsofJson(OptionsBuilderConfigurationExtensions =>
            //{
            //    Options.SerializerSettings.NullValueHandling = NullValuesHandling.Ignore;
            //});
            services.AddHttpClient();
            services.AddTransient<ISapServices, SapServices>();
            services.AddTransient<IAuthServices, AuthServices>();

            var keyVaultConfig = Configuration.GetSection("KeyVaultSetting").Get<KeyVaultSetting>();

            #if !DEBUG
            var keyvault = new KeyVault(keyVaultConfig);
            #else
            var keyvault = new KeyVault(keyVaultConfig.Name, true, "http://dalprx01.na.xom.com:8080");
            #endif
            keyvault.PopulateSecrets(Configuration);
        }

        

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}