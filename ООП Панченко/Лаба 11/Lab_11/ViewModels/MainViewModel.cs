using Lab_11.Commands;
using Lab_11.Models;
using Lab_11.Database;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Windows.Input;
using System.Windows;
using System;

namespace Lab_11.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private SpecializeContext context;
        private ObservableCollection<Specialize> specialization;
        private ObservableCollection<Customer> customers;
        private Specialize selectedSpecialize;
        private Customer selectedCustomer;
        private ICommand enrollCustomerCommand;
        private ICommand disenrollCustomerCommand;

        public MainViewModel()
        {
            context = new SpecializeContext();
            LoadData();
            enrollCustomerCommand = new RelayCommand(EnrollCustomer, CanEnrollCustomer);
            disenrollCustomerCommand = new RelayCommand(DisenrollCustomer, CanDisenrollCustomer);
        }

        public ObservableCollection<Specialize> Specializes
        {
            get { return specialization; }
            set
            {
                specialization = value;
                OnPropertyChanged(nameof(Specializes));
            }
        }

        public ObservableCollection<Customer> Customers
        {
            get { return customers; }
            set
            {
                customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }

        public Specialize SelectedSpecialize
        {
            get { return selectedSpecialize; }
            set
            {
                selectedSpecialize = value;
                OnPropertyChanged(nameof(SelectedSpecialize));
            }
        }

        public Customer SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                selectedCustomer = value;
                OnPropertyChanged(nameof(SelectedCustomer));
            }
        }

        public ICommand EnrollCustomerCommand
        {
            get { return enrollCustomerCommand; }
        }

        public ICommand DisenrollCustomerCommand
        {
            get { return disenrollCustomerCommand; }
        }

        private void LoadData()
        {
            try
            {
                Specializes = new ObservableCollection<Specialize>(context.Specializes.Include(c => c.Doctor).Include(c => c.Customers));
                Customers = new ObservableCollection<Customer>(context.Customers.Include(s => s.Specializes));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}");
            }
        }

        private bool CanEnrollCustomer(object parameter)
        {
            return SelectedSpecialize != null && SelectedCustomer != null && !SelectedSpecialize.Customers.Contains(SelectedCustomer);
        }

        private bool CanDisenrollCustomer(object parameter)
        {
            return SelectedSpecialize != null && SelectedCustomer != null && SelectedSpecialize.Customers.Contains(SelectedCustomer);
        }

        private void EnrollCustomer(object parameter)
        {
            try
            {
                if (SelectedSpecialize != null && SelectedCustomer != null)
                {
                    SelectedSpecialize.Customers.Add(SelectedCustomer);
                    context.SaveChanges();
                    OnPropertyChanged(nameof(SelectedSpecialize));
                    OnPropertyChanged(nameof(SelectedCustomer));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error enrolling customer: {ex.Message}");
            }
        }

        private void DisenrollCustomer(object parameter)
        {
            try
            {
                if (SelectedSpecialize != null && SelectedCustomer != null)
                {
                    SelectedSpecialize.Customers.Remove(SelectedCustomer);
                    context.SaveChanges();
                    OnPropertyChanged(nameof(SelectedSpecialize));
                    OnPropertyChanged(nameof(SelectedCustomer));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error disenrolling customer: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
