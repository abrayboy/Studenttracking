﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Studenttracking.Models
{
    public class StudentManager : ICollection<Student>
    {

        private ICollection<Student> students;

        public ICollection<Student> Students
        {
            get => students;
            set { this.students = value; }
        }

        public StudentManager()
        {
            this.students = new List<Student>();
        }

        public int Count => students.Count;

        public bool IsReadOnly => students.IsReadOnly;

        public Student this[int i] => ((IList<Student>) this.students)[i];

        public void Add(Student item)
        {
            students.Add(item);
        }

        public void Clear()
        {
            students.Clear();
        }

        public bool Contains(Student item)
        {
            return students.Contains(item);
        }

        public void CopyTo(Student[] array, int arrayIndex)
        {
            students.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Student> GetEnumerator()
        {
            return students.GetEnumerator();
        }

        public bool Remove(Student item)
        {
            return students.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return students.GetEnumerator();
        }
    }
}
