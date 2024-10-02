using ClassLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Sources;
using System.Xml.Serialization;

namespace ClassLibrary
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRespository _taskRepository;

        public TaskService(ITaskRespository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task AddTask(CreateTaskDTO addTaskDTO)
        {
            var taskInfo = new TaskInfo()
            {
                Title = addTaskDTO.Title,
                Description = addTaskDTO.Description,
                Deadline = addTaskDTO.Deadline,
                Priority = addTaskDTO.Priority
            };
            _taskRepository.CreateTask(taskInfo);
            await Task.CompletedTask;
        }

        public async Task EditTask(EditTaskDTO editTaskDTO)
        {
            var existingTask = await _taskRepository.GetById(editTaskDTO.ID);
            if (existingTask == null)
            {
                throw new Exception("Zadanie nie zostało znalezione.");
            }
            existingTask.Title = editTaskDTO.Title;
            existingTask.Description = editTaskDTO.Description;
            existingTask.Deadline = editTaskDTO.Deadline;
            existingTask.Priority = editTaskDTO.Priority;
            await _taskRepository.UpdateTaskAsync(existingTask);
        }

        public List<TaskInfo> GetAllTasks()
        {
            return _taskRepository.GetAll();
        }

        public async Task RemoveTask(int id)
        {
            var tasks = _taskRepository.GetAll();
            var taskToDelete = tasks.FirstOrDefault(t => t.Id == id);
            if (taskToDelete == null)
            {
                throw new Exception("Zadanie nie zostało znalezione.");
            }

            await _taskRepository.DeleteTaskAsync(tasks, id);
        }
    }
}