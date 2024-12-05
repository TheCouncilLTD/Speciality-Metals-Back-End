using Microsoft.EntityFrameworkCore;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Customer_Models;
using Speciality_Metals_Back_End.SpecialityMetals_Models.EmployeeType_Models;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Incoming_Models;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Outgoing_Models;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Product_Models;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Staff_Models;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Sundry;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Supplier;
using Speciality_Metals_Back_End.SpecialityMetals_Models.Sundry_Notes_Models;
using Speciality_Metals_Back_End.SpecialityMetals_Models.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Speciality_Metals_Back_End.SpecialityMetals_Models.ReportingCustomer;
using Speciality_Metals_Back_End.SpecialityMetals_Models.ReportingProduct;
using Speciality_Metals_Back_End.SpecialityMetals_Models.AllDeliveriesWeighed;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp",
        builder => builder
            .WithOrigins("http://localhost:4200")  // Angular app origin
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Add services to the container
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DbContexts and Repositories
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

builder.Services.AddDbContext<Sundry_Notes_Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<iSundry_Notes_Repository, Sundry_Notes_Repository>();


builder.Services.AddDbContext<ReportCust_Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IReportCust_Repository, ReportCust_Repository>();

builder.Services.AddDbContext<ReportProduct_Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IReportProduct_Repository, ReportProduct_Repository>();

builder.Services.AddDbContext<AllDeliveriesWeighedContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddScoped<IAllDeliveriesWeighedRepository, AllDeliveriesWeighedRepository>();


// Configure JWT settings
var jwtSettingsSection = builder.Configuration.GetSection("JWTSettings"); // Matches the config key
builder.Services.Configure<JWTSettings>(jwtSettingsSection);

var jwtSettings = jwtSettingsSection.Get<JWTSettings>();
var key = Encoding.UTF8.GetBytes(jwtSettings.Key);

// Add authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };
});
builder.Services.AddScoped<JwtHelper>();

var app = builder.Build();


// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAngularApp");

app.UseAuthentication(); // Add authentication middleware
app.UseAuthorization();

app.MapControllers();

app.Run();