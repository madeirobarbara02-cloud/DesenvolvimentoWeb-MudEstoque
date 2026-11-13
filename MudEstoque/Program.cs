using Microsoft.EntityFrameworkCore;
using MudBlazor;
using MudBlazor.Services;
using MudEstoque.Components;
using MudEstoque.Data;
using MudEstoque.Services.Implementations;
using MudEstoque.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Fábrica de DbContext: um contexto curto por operação
builder.Services.AddDbContextFactory<EstoqueDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro dos serviços de negócio (Injeção de Dependência)
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
builder.Services.AddScoped<IFornecedorService, FornecedorService>();
builder.Services.AddScoped<IProdutoService, ProdutoService>();

// MudBlazor: configuração global de Snackbar e Dialogs
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass    = Defaults.Classes.Position.BottomRight;
    config.SnackbarConfiguration.VisibleStateDuration   = 3500;
    config.SnackbarConfiguration.ShowTransitionDuration = 200;
    config.SnackbarConfiguration.HideTransitionDuration = 200;
    config.SnackbarConfiguration.PreventDuplicates      = false;
    config.SnackbarConfiguration.NewestOnTop            = false;
    config.SnackbarConfiguration.SnackbarVariant        = Variant.Filled;
});

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
