using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CurrencyConverterMVVM.ViewModels;
using CurrencyConverterMVVM.Data;

namespace CurrencyConverterMVVM.Commands
{
    public class AddCommand : ICommand
    {
        private MainWindowViewModel _viewModel;

        public AddCommand(MainWindowViewModel viewModel)
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
            return true;
        }

        public void Execute(object parameter)
        {
            try
            {
                {
                    Currency getSelectedValue = _viewModel.SelectedCurrency;
                    //using this bind the collection .. 
                    if (getSelectedValue != null)
                    {
                        var data = _viewModel.lstAddedCurrencies.FirstOrDefault(item => item.Id == getSelectedValue.Id);
                        switch (data)
                        {
                            case null:
                                _viewModel.lstAddedCurrencies.Add(getSelectedValue);
                                _viewModel.DisplayErrorMessage(string.Empty);
                                _viewModel._unsavedChanges = true;
                                break;
                            default:
                                _viewModel.DisplayErrorMessage("This Currency was already added.");
                                break;
                        }
                    }
                    else
                    {
                        _viewModel.DisplayErrorMessage("Please select the Currency."); ;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

