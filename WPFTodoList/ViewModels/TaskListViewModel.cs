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
            testList.Add(new TaskViewModel("Walk Dog", DateTime.Today));
            testList.Add(new TaskViewModel("Write English Paper", DateTime.Today));
            testList.Add(new TaskViewModel("PHL Reading pg.27", DateTime.Today));

            testList[1].AddSubTask(new TaskViewModel("Write Thesis", DateTime.Today));
            testList[1].AddSubTask(new TaskViewModel("Write Response", DateTime.Today));
            testList[1].AddSubTask(new TaskViewModel("Refactor Paper", DateTime.Today));

            testList[2].AddSubTask(new TaskViewModel("Read & Annotate", DateTime.Now));
            testList[2].AddSubTask(new TaskViewModel("Review & Summerize", DateTime.Now));


            return testList;
        }
    }
}
