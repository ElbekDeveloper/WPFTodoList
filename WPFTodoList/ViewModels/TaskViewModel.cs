using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WPFTodoList.ViewModels
{
    public class TaskViewModel : ObservableObject, ITask
    {
        private string _title;
        private string _content;
        private bool _complete;
        private DateTime _creationDate;
        private DateTime _dueDate;
        private List<ITask> _subTasks;

        public ICommand CheckedCommand { get; private set; }

        public string Title
        {
            get{ return _title; }
            set { onpropertychanged(ref _title, value); }
        }

        public string Content
        {
            get { return _content; }
            set { onpropertychanged(ref _content, value); }
        }

        public bool Complete
        {
            get { return _complete; }
            set { onpropertychanged(ref _complete, value);
                OnPropertyChanged("Status"); }
        }

        public DateTime CreationDate
        {
            get { return _creationDate; }
            set { onpropertychanged(ref _creationDate, value); }
        }

        public DateTime DueDate
        {
            get { return _dueDate; }
            set { onpropertychanged(ref _dueDate, value); }
        }

        public List<ITask> SubTasks
        {
            get { return _subTasks; }
            set { onpropertychanged(ref _subTasks, value); }
        }

        public string Status
        {
            get
            {
                return Complete == true ? "Task Completed" : "Task Incomplete";
            }
        }


        public TaskViewModel(string title, DateTime dueDate)
        {
            Title = title;
            DueDate = dueDate;
            CreationDate = DateTime.Now;
            SubTasks = new List<ITask>();

            CheckedCommand = new RelayCommand(TaskChecked);
        }

        public TaskViewModel(string title, string content, DateTime dueDate) : this(title, dueDate)
        {
            Content = content;
        }

        public void AddSubTask(ITask task)
        {
            SubTasks.Add(new TaskViewModel(task.Title, task.DueDate));
        }

        public void TaskChecked(object param)
        {
            Complete = !Complete;
        }
    }
}
