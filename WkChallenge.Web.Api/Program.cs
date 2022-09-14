using WkChallenge.Web.Api;
using Microsoft.OpenApi.Models;
using WkChallenge.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using WkChallenge.Infrastructure.Data;
using WkChallenge.Web.Api.MappingProfiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
							   {
								   options.SwaggerDoc("v1", new OpenApiInfo {Title = "WkChallenge.Web.Api", Version = "v1"});
								   options.EnableAnnotations();
								   options.OperationFilter<SwaggerExtensions.CustomOperationFilters>();
								   options.CustomSchemaIds(type => type.Name.Replace("Dto", ""));
							   });
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(CategoryProfile).Assembly, typeof(ProductProfile).Assembly);
builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapControllers());
app.MigrateDatabase();
app.Run();
