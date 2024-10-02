using ClassLibrary.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class JsonClassRepository : ITaskRespository
    {
        private readonly string filePath = "NotesData";


        public void CreateTask(TaskInfo task)
        {
            var tasks = GetAll();
            var nextID = tasks.Count + 1;
            task.Id = nextID;
            tasks.Add(task);
            SaveTask(tasks);
        }

        public Task DeleteTaskAsync(List<TaskInfo> task, int id)
        {
            var taskToDelete = task.FirstOrDefault(t => t.Id == id);
            if (taskToDelete != null) 
            {
                task.Remove(taskToDelete);
                SaveTask(task);
            }
            return Task.CompletedTask;
        }

        public List<TaskInfo> GetAll()
        {
            if (!File.Exists(filePath))
            {
                return new List<TaskInfo>();
            }

            var jsonData = File.ReadAllText(filePath);
            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<TaskInfo>>(jsonData) ?? new List<TaskInfo>();
        }

        public async Task<TaskInfo?> GetById(int id)
        {
            var tasks = GetAll();
            var task = tasks.FirstOrDefault(task => task.Id == id);
            return  await Task.FromResult(task);
        }

        public void SaveTask(List<TaskInfo> tasks)
        {
            var jsonData = JsonConvert.SerializeObject(tasks, Formatting.Indented);
            File.WriteAllText(filePath, jsonData);
        }

        public Task UpdateTaskAsync(TaskInfo task)
        {
            var tasks = GetAll();
            var excistingTask = tasks.FirstOrDefault(t => t.Id == task.Id);
            if (excistingTask != null)
            { 
                SaveTask(tasks);
            }
            else
            {
                throw new Exception("zadanie nie znlezione");
            }
            return Task.CompletedTask;
        }
    }
}
