using Microsoft.EntityFrameworkCore;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Customer_Models;
using Speciality_Metals_Back_End.SpecialityMetals_Models.EmployeeType_Models;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Incoming_Models;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Outgoing;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Product_Models;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Staff_Models;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Sundry;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Supplier;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder => builder
            .WithOrigins("http://localhost:4200")  // Angular app origin
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registering the DbContexts and corresponding Repositories
builder.Services.AddDbContext<Employee_Type_Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IEmployee_Type_Repository, Employee_Type_Repository>();

builder.Services.AddDbContext<Staff_Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IStaff_Repository, Staff_Repository>();

builder.Services.AddDbContext<Product_Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IProduct_Repository, Product_Repository>();

builder.Services.AddDbContext<Customer_Conext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

builder.Services.AddDbContext<Supplier_Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ISupplier_Repository, Supplier_Repository>();

builder.Services.AddDbContext<SundryContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<ISundryRepository, SundryRepository>();

builder.Services.AddDbContext<Outgoing_Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IOutgoing_Repository, Outgoing_Repository>();

builder.Services.AddDbContext<Incoming_Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IIncoming_Repository, IncomingRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAngularApp");
app.UseAuthorization();

app.MapControllers();

app.Run();
