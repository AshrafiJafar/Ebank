using Framework.AssemblyHelper;
using Framework.DependencyInjection;
using Framework.Facade;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Ebank.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

var assemblyHelper = new AssemblyHelper("Ebank");
Registrar(builder, assemblyHelper);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mvcBuilder = builder.Services.AddMvc(option =>
{
    option.EnableEndpointRouting = false;
})
                .AddNewtonsoftJson(o =>
                {
                    o.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

AddControllers(assemblyHelper, mvcBuilder);

var app = builder.Build();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();

app.MapControllers();

app.Run();


void Registrar(WebApplicationBuilder builder, AssemblyHelper assemblyHelper)
{
    
    var registrars = assemblyHelper.GetInstanceByInterface(typeof(IRegistrar));
    foreach (IRegistrar registrar in registrars)
        registrar.Register(builder.Services);

}


static void AddControllers(AssemblyHelper assemblyHelper, IMvcBuilder mvcBuilder)
{
    var controllerAssemblies = assemblyHelper.GetAssemblies(typeof(FacadeCommandBase)).Distinct();

    foreach (var apiControllerAssembly in controllerAssemblies)
        mvcBuilder.AddApplicationPart(apiControllerAssembly);

    controllerAssemblies = assemblyHelper.GetAssemblies(typeof(FacadeQueryBase)).Distinct();
    foreach (var apiControllerAssembly in controllerAssemblies)
        mvcBuilder.AddApplicationPart(apiControllerAssembly);
}
