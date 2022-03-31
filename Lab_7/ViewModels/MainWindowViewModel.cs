using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Text.Json;
using Lab_7.Models;

namespace Lab_7.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Students = new ObservableCollection<StudentData>(CreateTestStudents());
        }

        public ObservableCollection<StudentData> Students { get; set; }
        private int studentCount = 0;

        public void AddNewStudent()
        {
            studentCount++;
            Students.Add(new StudentData("Студент " + Convert.ToString(studentCount))); 
        }

        public void DeleteSelectedStudents ()
        {

            for (int i = 0; i < Students.Count;)
            {
                if (Students[i].IsWillDelete == true)
                {
                    Students.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        }
        public List<StudentData> CreateTestStudents()
        {
            List<StudentData> testStudents = new List<StudentData>();
            for (int i = 0; i < 5; i++)
            {
                studentCount++;
                testStudents.Add(new StudentData("Студент " + Convert.ToString(studentCount)));
            }
            return testStudents;
        }
    }
}
