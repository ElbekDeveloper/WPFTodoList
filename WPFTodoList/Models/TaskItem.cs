using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTodoList.Models
{
    public class TaskItem : ITask
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public bool Complete { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DueDate { get; set; }

        public TaskItem(string title, DateTime dueDate)
        {
            Title = title;
            DueDate = dueDate;
            CreationDate = DateTime.Now;
        }

        public TaskItem(string title, string content, DateTime dueDate) : this(title, dueDate)
        {
            Content = content;
        }

    }
}
