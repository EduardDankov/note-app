using Microsoft.EntityFrameworkCore;

using NoteApp.Api;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Database>(optionsAction => optionsAction.UseInMemoryDatabase("NoteApp"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddControllers().AddControllersAsServices();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseRouting();

app.MapControllers();

app.Run();
