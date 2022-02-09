using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Task19.Models;

namespace Task19.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        private double radius;
        public double Radius
        {
            get => radius;
            set
            {
                radius = value;
                OnPropertyChanged();
            }
        }
       
        private double lenght;
        public double Lenght
        {
            get => lenght;
            set
            {
                lenght = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; }
        private void OnAddCommandExecuted(object p) //метод, который должен выполнять вычисление
        //длины окружности и результут присваивать в поле Lenght
        {
            Lenght = Ariph.Add(Radius);
        }
        private bool CanAddCommandExecuted(object p) //метод проверяющий возможность выполнения команды вычисления
        {
            if (Radius > 0)
                return true;
            else
                return false;
        }
        public MainWindowViewModel() //конструктор
        {
            AddCommand = new RelayCommand(OnAddCommandExecuted, CanAddCommandExecuted);
        }
    }
}

