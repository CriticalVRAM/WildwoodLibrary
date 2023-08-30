using ASPNedelja3Vezbe.Api.Core;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;
using WildwoddLib.DataAccess;
using WildwoodLib.API.Core;
using WildwoodLib.Application;
using WildwoodLib.Application.UseCase;
using WildwoodLib.Application.UseCases.Entity.User;
using WildwoodLib.Domain.Entites;
using WildwoodLib.Implementation;
using WildwoodLib.Implementation.Logging;
using WildwoodLib.Implementation.UseCase;
using WildwoodLib.Implementation.UseCase.Book;
using WildwoodLib.Implementation.UseCase.Category;
using WildwoodLib.Implementation.UseCase.Checkout;
using WildwoodLib.Implementation.UseCase.User;
using WildwoodLib.Implementation.UseCase.UserUseCase;
using WildwoodLib.Implementation.UseCase.Writter;
using static WildwoodLib.Application.UseCase.Entity.Book.Book;
using static WildwoodLib.Application.UseCase.Entity.Category.Category;
using static WildwoodLib.Application.UseCase.Entity.Checkout.Checkout;
using static WildwoodLib.Application.UseCase.Entity.UserUseCase.UserUseCase;
using static WildwoodLib.Application.UseCase.Entity.Writter.Writer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer",
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
             Type = ReferenceType.SecurityScheme,
             Id = "Bearer",
            }
        },
        new string[] { }
     }
    });
});


//////////////////////////
#region JWT Authorization
JwtSettings JwtSettings = new();
builder.Configuration.GetSection("JwtSettings").Bind(JwtSettings);
builder.Services.AddSingleton(JwtSettings);
builder.Services.AddTransient<JwtManager>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = JwtSettings.Issuer,
        ValidateIssuer = true,
        ValidAudience = "Any",
        ValidateAudience = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtSettings.SecretKey)),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero
    };
});
// JWT to User Object
builder.Services.AddTransient<IAppUser>(x =>
{
    var accessor = x.GetService<IHttpContextAccessor>() ?? throw new NullReferenceException();
    if (accessor.HttpContext == null) throw new NullReferenceException();
    var claims = accessor.HttpContext.User ?? throw new NullReferenceException();

    if (claims == null || claims.FindFirst("UserId") == null)
    {
        return new AnonimousUser();
    }

    var actor = new JwtUser
    {
        Id = int.Parse(claims.FindFirst("UserId")!.Value),
        Identity = claims.FindFirst("Identity")!.Value,
        UseCaseIds = JsonConvert.DeserializeObject<List<int>>(claims.FindFirst("UseCases").Value)
    };

    return actor;
});
#endregion


builder.Services.AddTransient<WildwoodLibContext>();

// Cross-cutting Concerns
builder.Services.AddTransient<UseCaseHandler>();
builder.Services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddTransient<IUseCaseLogger, EfUseCaseLogger>();

// UseCases
#region UseCases
builder.Services.AddTransient<ISeedDataCommand, EfSeedDataCommand>();

builder.Services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
builder.Services.AddTransient<ICreateUserCommand, EfCreateUserCommand>();
builder.Services.AddTransient<IEditUserCommand, EfEditUserCommand>();
builder.Services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();

builder.Services.AddTransient<IGetWritersQuery, EfGetWriterQuery>();
builder.Services.AddTransient<ICreateWriterCommand, EfCreateWriterCommand>();
builder.Services.AddTransient<IDeleteWriterCommand, EfDeleteWriterCommand>();

builder.Services.AddTransient<IGetUserUseCaseQuery, EfGetUserUseCasesQuery>();
builder.Services.AddTransient<ICreateUserUseCaseCommand, EfCreateUserUseCaseCommand>();
builder.Services.AddTransient<IDeleteUserUseCaseCommand, EfDeleteUserUseCaseCommand>();

builder.Services.AddTransient<IGetBooksQuery, EfGetBooksQuery>();
builder.Services.AddTransient<ICreateBookCommand, EfCreateBookCommand>();
builder.Services.AddTransient<IUpdateBookCommand, EfUpdateBookCommand>();
builder.Services.AddTransient<IDeleteBookCommand, EfDeleteBookCommand>();

builder.Services.AddTransient<IGetCategoryQuery, EfGetCategoryQuery>();
builder.Services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>();
builder.Services.AddTransient<IUpdateCategoryCommand, EfUpdateCategoryCommand>();
builder.Services.AddTransient<IDeleteCategoryCommand, EfDeleteCategoryCommand>();

builder.Services.AddTransient<IGetCheckoutQuery, EfGetCheckoutQuery>();
builder.Services.AddTransient<IGetUserCheckoutQuery, EfGetUserCheckoutQuery>();
builder.Services.AddTransient<ICreateCheckoutCommand, EfCreateCheckoutCommand>();
builder.Services.AddTransient<IUpdateCheckoutCommand, EfUpdateCheckoutCommand>();
builder.Services.AddTransient<IDeleteCheckoutCommand, EfDeleteCheckoutCommand>();
#endregion

//////////////////////////
var app = builder.Build();
#region AppStart
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandler>();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion
