using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.DTO
{
    public record CreateTaskDTO(string Title, string Description, DateTime Deadline, int Priority);
    public record EditTaskDTO(int ID, string? Title, string Description, DateTime Deadline, int Priority);
    
}
