using ClassLibrary;
using Microsoft.Extensions.DependencyInjection;

var serviceProvider = new ServiceCollection()
    .AddSingleton<ITaskRespository, JsonClassRepository>()
    .AddSingleton<ITaskService, TaskService>()
    .AddSingleton<TaskController>()
    .BuildServiceProvider();

var taskController = serviceProvider.GetRequiredService<TaskController>();
taskController.Choosing();