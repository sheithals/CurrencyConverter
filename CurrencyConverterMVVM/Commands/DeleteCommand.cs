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
    public class DeleteCommand : ICommand
    {
        private MainWindowViewModel _viewModel;

        public DeleteCommand(MainWindowViewModel viewModel)
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
                Currency getSelectedItemCurrency = _viewModel.SelectedItemCurrency;
                if (getSelectedItemCurrency != null)
                {
                    if (_viewModel.lstAddedCurrencies.Count > 0)
                    {
                        //_viewModel.lstAddedCurrencies.Remove(getSelectedItemCurrency);

                        #region make it null only when the selected item is same else leave it as it is

                        if ((_viewModel.SelectedFromCurrency != null && getSelectedItemCurrency.Id == _viewModel.SelectedFromCurrency.Id) ||
                          _viewModel.SelectedToCurrency != null &&  getSelectedItemCurrency.Id == _viewModel.SelectedToCurrency.Id)
                        {
                            _viewModel.ConvertedCurrency = string.Empty;
                            _viewModel.EnteredCurrency = string.Empty;
                            _viewModel.SelectedFromCurrency = null;
                            _viewModel.SelectedToCurrency = null;
                            _viewModel._unsavedChanges = true;
                        }
                        _viewModel.lstAddedCurrencies.Remove(getSelectedItemCurrency);
                        #endregion  
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

