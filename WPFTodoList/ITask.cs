using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTodoList
{
    public interface ITask
    {
        string Title { get; set; }
        string Content { get; set; }

        bool Complete { get; set; }

        DateTime CreationDate { get; set; }
        DateTime DueDate { get; set; }

        List<ITask> SubTasks { get; set; }

        void AddSubTask(ITask task);
    }
}
