using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SWD_Order.Repo.Entity;
using SWD_Order.Repo.Interface;
using SWD_Order.Repo.Repository;
using SWD_Order.Service.Mapper;
using SWD_Order.Service.OrderService;
using SWD_Order.Service.ProductService;

var builder = WebApplication.CreateBuilder(args);
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperProfile());
});
var mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IImageRepository, ImageRepository>();
builder.Services.AddCors(option => option.AddPolicy("Dbcontext", build =>
{

    build.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
}));
builder.Services.AddAuthorization(option =>
{
    option.AddPolicy("Dbcontext", policy =>
    {
        policy.RequireAuthenticatedUser();

    });
});

//builder.Services.AddTransient<IProductAddRepository, ProductAddRepository>();
builder.Services.AddDbContext<WPF_MachineContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("POS"));
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("Dbcontext");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
