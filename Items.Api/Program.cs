var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<AppSettings>(builder.Configuration);

var configuration = builder.Configuration.Get<AppSettings>();

builder.Services.AddDbContext<ItemsDbContext>(options =>
{
    options.UseNpgsql(configuration!.ConnectionStrings.PostgreSqlConnection);
});

builder.Services.AddHttpLogging(logging =>
{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.MediaTypeOptions.AddText("application/json");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;
    logging.CombineLogs = true;
});

builder.Services.AddProblemDetails();

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddTransient<IItemsService, ItemsService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpLogging();

app.UseRouting();

app.MapControllers();

app.UseHttpsRedirection();

app.Run();