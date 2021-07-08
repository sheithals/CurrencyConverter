using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using CurrencyConverterMVVM.Data;

using CurrencyConverterMVVM.ViewModels;
namespace CurrencyConverterMVVM.Commands
{
    public class SwitchCommand : ICommand
    {
        private MainWindowViewModel _viewModel;

        public SwitchCommand(MainWindowViewModel viewModel)
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
            try
            {
                // swap both values here
                if (_viewModel.SelectedFromCurrency != null && _viewModel.SelectedToCurrency != null)
                {
                    Currency currValue = _viewModel.SelectedFromCurrency;
                    Currency currvaluenew = _viewModel.SelectedToCurrency;

                    _viewModel.SelectedFromCurrency = currvaluenew;
                    _viewModel.SelectedToCurrency = currValue;
                    _viewModel._unsavedChanges = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
