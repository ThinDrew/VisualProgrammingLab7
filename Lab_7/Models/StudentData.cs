using System;
using System.Collections.ObjectModel;
using Avalonia.Media;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Lab_7.Models
{
    public class StudentData : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public ObservableCollection<Cell> Subject { get; set; }
        IBrush background;
        public IBrush Background
        {
            get => background;
            set
            {
                background = value;
                NotifyPropertyChanged();
            }
        }

        private double averageValue;
        public double AverageValue 
        {
            get => averageValue;
            set
            {
                averageValue = value;
                NotifyPropertyChanged();
                double val = Convert.ToDouble(value);
                if (val < 1) Background = Brushes.Red;
                else if (val < 1.5) Background = Brushes.Yellow;
                else Background = Brushes.Green;
            }
        }
        public bool ?IsWillDelete { get; set; }

        public StudentData (string name)
        {
            Name = name;
            IsWillDelete = false;
            Subject = new ObservableCollection<Cell>(CreateSubjects());
            AverageValue = 0;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
       

        private ObservableCollection<Cell> CreateSubjects()
        {
            ObservableCollection < Cell> subject = new ObservableCollection<Cell>();
            for (int i = 0; i < 5; i++)
            {
                subject.Add(new Cell("0"));
            }
            return subject;
        }

        public void CalculateAverage()
        {
            double sum = 0;

            for (int i = 0; i < Subject.Count; i++)
            {

                if (Subject[i].Mark != "#ERROR")
                {
                    sum += Convert.ToDouble(Subject[i].Mark);
                }
            }
            sum /= Subject.Count;
            AverageValue = sum;
        }
    }
}
