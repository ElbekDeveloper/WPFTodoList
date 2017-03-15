using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFTodoList.Models;

namespace WPFTodoList.ViewModels
{
    public class TaskListViewModel : ObservableObject
    {
        private List<ITask> _taskItems;
        public List<ITask> TaskItems
        {
            get
            {
                return _taskItems;
            }
            set
            {
                _taskItems = value;
                OnPropertyChanged("TaskItems");
            }
        }
    }
}
