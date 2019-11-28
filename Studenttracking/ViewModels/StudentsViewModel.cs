using Studenttracking.Extensions;
using Studenttracking.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Studenttracking.ViewModels
{
    public class StudentsViewModel : INotifyPropertyChanged
    {

        private StudentManager studentManager;
        private ObservableCollection<Student> students;

        public StudentManager StudentManager
        {
            get => this.studentManager;
            set
            {
                this.studentManager = value;
                this.OnPropertyChanged();
            }
        }

        public ObservableCollection<Student> Students
        {
            get => this.students;
            set
            {
                this.students = value;
                this.OnPropertyChanged();
            }
        }

        public StudentsViewModel()
        {
            this.StudentManager = new StudentManager();
            this.Students = new ObservableCollection<Student>();
        }

        public void Add(Student student)
        {
            this.studentManager.Add(student);
            this.Students = this.studentManager.ToObservableCollection();
        }

        public void Remove(Student student)
        {
            this.studentManager.Remove(student);
            this.Students = this.studentManager.ToObservableCollection();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
