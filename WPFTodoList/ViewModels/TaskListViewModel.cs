using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WPFTodoList.ViewModels
{
    public class TaskListViewModel : ObservableObject
    {
        private List<ITask> _taskItems;
        public List<ITask> TaskItems
        {
            get { return _taskItems; }
            set { onpropertychanged(ref _taskItems, value); }
        }

        private ITask selectedTask;
        public ITask SelectedTask
        {
            get { return selectedTask; }
            set { onpropertychanged(ref selectedTask, value);
                  OnPropertyChanged("SelectionVisible"); }
        }

        public Visibility SelectionVisible
        {
            get
            {
                if (SelectedTask != null) return Visibility.Visible;
                return Visibility.Hidden;
            }
        }

        public TaskListViewModel()
        {
            LoadTasks(TestTasks());
        }

        private void LoadTasks(List<ITask> taskCollection)
        {
            TaskItems = taskCollection;
        }

        private List<ITask> TestTasks()
        {
            var testList = new List<ITask>();
            testList.Add(new TaskViewModel("Test Task 1", DateTime.Today));
            testList.Add(new TaskViewModel("Test Task 2", DateTime.Today));
            testList.Add(new TaskViewModel("Test Task 3", DateTime.Today));

            var i = 0;
            foreach (var s in testList)
            {
                s.AddSubTask(new TaskViewModel("Sub" + i, DateTime.Today));
                i++;
            }
            return testList;
        }
    }
}
