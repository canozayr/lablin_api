using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);
var policyName = "_myAllowSpecificOrigins";
// Add services to the container.
builder.WebHost.UseUrls("http://srv-01:5000");
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
        builder =>
        {
            builder
            .WithHeaders(HeaderNames.ContentType)
            .WithMethods("POST", "GET")  // Allow both POST and GET
            .WithOrigins("*");
            //.AllowAnyOrigin()
            
        });
});

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.Limits.MaxRequestBodySize =null;
});

var app = builder.Build();
app.UseCors(policyName);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
