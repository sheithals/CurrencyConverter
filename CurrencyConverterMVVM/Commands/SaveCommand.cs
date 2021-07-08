using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using CurrencyConverterMVVM.ViewModels;

namespace CurrencyConverterMVVM.Commands
{
    public class SaveCommand : ICommand
    {
        private MainWindowViewModel _viewModel;

        public SaveCommand(MainWindowViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            //return _viewModel.IsValid;
            return true;
        }

        public void Execute(object parameter)
        {            
            _viewModel.SaveChanges();        
        }
    }
}

