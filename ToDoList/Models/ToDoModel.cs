using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Models
{
    class ToDoModel : INotifyPropertyChanged
    {
        public DateTime DateTask { get; set; } = DateTime.Now;

        private bool done;
        private string taskName;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string nameProp)
        {
            //if(PropertyChanged!= null)
            //{
            //    PropertyChanged(this, new PropertyChangedEventArgs(nameProp));
            //}
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameProp));
        }

        public bool Done
        {
            get => done;
            set
            {
                if (done == value) return;
                done = value;
                OnPropertyChanged("Done");
            }
        }

        public string TaskName
        {
            get => taskName;
            set
            {
                if (taskName == value) return;
                taskName = value;
                OnPropertyChanged("TaskName");
            }
        }
    }
}
