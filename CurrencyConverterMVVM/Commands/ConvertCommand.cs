using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CurrencyConverter.Enums;
using CurrencyConverter;
using CurrencyConverterMVVM.ViewModels;



namespace CurrencyConverterMVVM.Commands
{
    public class ConvertCommand : ICommand
    {
        private MainWindowViewModel _viewModel;

        public ConvertCommand(MainWindowViewModel viewModel)
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
                if (String.IsNullOrEmpty(_viewModel.EnteredCurrency) || _viewModel.SelectedFromCurrency == null || _viewModel.SelectedToCurrency == null)
                {
                    _viewModel.DisplayErrorMessage("Please enter all the details before you convert.");
                    return;
                }
                else
                {

                    var selectedFromCurrency = _viewModel.SelectedFromCurrency;
                    var selectedToCurrency = _viewModel.SelectedToCurrency;
                    var enteredCurrency = Convert.ToDouble(_viewModel.EnteredCurrency);

                    CurrencyType ctype1 = (CurrencyType)Enum.Parse(typeof(CurrencyType), selectedFromCurrency.Id, true);

                    CurrencyType ctyp2 = (CurrencyType)Enum.Parse(typeof(CurrencyType), selectedToCurrency.Id, true);

                    var convertedCurrency = _viewModel.PremiumConverter.Convert(enteredCurrency, ctype1, ctyp2);
                    //display it to the label 
                    _viewModel.ConvertedCurrency = convertedCurrency.ToString();
                    _viewModel.DisplayErrorMessage(string.Empty);
                    _viewModel._unsavedChanges = true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
            }
        }
    }
}
