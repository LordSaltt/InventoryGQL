using System.Text;
using System.Threading.Tasks;
using GraphqlServer.Data;
using GraphqlServer.DataLoader;
using GraphqlServer.Queries;
using GraphqlServer.Queries.Brands;
using GraphqlServer.Queries.Categories;
using GraphqlServer.Queries.Login;
using GraphqlServer.Queries.Products;
using GraphqlServer.Queries.Register;
using GraphqlServer.Queries.Suppliers;
using GraphqlServer.Shared;
using GraphqlServer.Types;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace GraphqlServer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {


            services.Configure<TokenSettings>(Configuration.GetSection("TokenSettings"));
            
            services.AddPooledDbContextFactory<ApplicationDbContext>(options =>
                    options.UseSqlServer(
                        Configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddGraphQLServer()
                .AddQueryType(d => d.Name("Query"))
                    .AddTypeExtension<ProductQueries>()
                    .AddTypeExtension<BrandQueries>()
                    .AddTypeExtension<CategoryQueries>()
                    .AddTypeExtension<SupplierQueries>()
                    .AddTypeExtension<LoginQueries>()
                .AddMutationType(d => d.Name("Mutation"))
                    .AddTypeExtension<ProductMutation>()
                    .AddTypeExtension<BrandMutation>()
                    .AddTypeExtension<CategoryMutation>()
                    .AddTypeExtension<SupplierMutation>()
                    .AddTypeExtension<LoginMutation>()                   
                    .AddTypeExtension<RegisterUserMutation>()                   
                .AddSubscriptionType(d => d.Name("Subscription"))
                    .AddTypeExtension<ProductsSubscription>()
                    .AddTypeExtension<SuppliersSubscription>()
                .AddType<ProductType>()
                .AddType<BrandType>()
                .AddType<CategoryType>()
                .AddType<SupplierType>()
                .AddType<UserType>()
                .EnableRelaySupport()
                .AddInMemorySubscriptions()
                .AddDataLoader<ProductByIdDataLoader>()
                .AddDataLoader<CategoryByIdDataLoader>()
                .AddDataLoader<BrandByIdDataLoader>()
                .AddDataLoader<SupplierByIdDataLoader>()
                .AddDataLoader<SupplierProductByIdDataLoader>()                
                .AddAuthorization();

            // Add CORS
            services.AddCors();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = Configuration.GetSection("TokenSettings").GetValue<string>("Issuer"),
                    ValidateIssuer = true,
                    ValidAudience = Configuration.GetSection("TokenSettings").GetValue<string>("Audience"),
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("TokenSettings").GetValue<string>("Key"))),
                    ValidateIssuerSigningKey = true
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebSockets();
            app.UseRouting();

            app.UseCors(c => c.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseAuthentication();
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });
        }
    }
}
