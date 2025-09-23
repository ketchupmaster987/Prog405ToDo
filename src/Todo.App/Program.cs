using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Todo.Common.Services;
internal class Program
{
    private static async void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddTransient<ITaskService, TaskService>();
        await builder.Build().RunAsync();
    }
}