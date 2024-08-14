using Acr.UserDialogs;
using SvaraKalkulators.Checklist.ViewModels.Base;
using SvaraKalkulators.Core.Data.Enums;
using SvaraKalkulators.Core.Data.Models.Data;
using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SvaraKalkulators.Checklist.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private bool _isKeyboardEnabled;
        private CalculatorMode _calculatorMode;
        private string _input = "";
        private float _weight;
        public float _result;
        private int _numbersToDegree;

        public MainViewModel()
        {
        }

        public ICommand CalculatorModeSwitchCommand => new Command<object>(CalculatorModeSwitch);

        public ICommand CalculateCommand => new Command(Calculate);

        public ICommand ResetResultCommand => new Command(ResetResult);

        public bool IsKeyboardEnabled
        {
            get => _isKeyboardEnabled;
            set
            {
                _isKeyboardEnabled = value;
                OnPropertyChanged();
            }
        }

        public CalculatorMode CalculatorMode
        {
            get => _calculatorMode;
            set
            {
                _calculatorMode = value;
                OnPropertyChanged();
            }
        }
        public int NumberToDegree
        {
            get => _numbersToDegree;
            set
            {
                _numbersToDegree = value;
                OnPropertyChanged();
            }
        }

        public string Input
        {
            get => _input;
            set
            {
                _input = value;
                //if(_input.Length == 12)
                //{
                //    Calculate();
                //}
                OnPropertyChanged();
            }
        }

        public float Weight
        {
            get => _weight;
            set
            {
                _weight = value;
                OnPropertyChanged();
            }
        }

        public float Result
        {
            get => _result;
            set
            {
                _result = value;
                if (_result < 0)
                    _result = 0;
                OnPropertyChanged();
            }
        }

        public string InputFirstChars => Input.Substring(0, 2);

        private void CalculatorModeSwitch(object parameter)
        {
            if (parameter != null)
            {
                Enum.TryParse(parameter.ToString(), out CalculatorMode result);
                CalculatorMode = result;
            }
        }

        private void Calculate()
        {
            try
            {
                if (Input.Length == 13)
                {
                    if (!(InputFirstChars == "22" 
                        || InputFirstChars == "23" 
                        || InputFirstChars == "27"
                        || InputFirstChars == "29"))
                    {
                        UserDialogs.Instance.Alert("Barcode should begin from 22, 23, 27 or 29.");
                        Input = "";
                        return;
                    }

                    Input = Input.Substring(0, Input.Length - 1);

                    switch (InputFirstChars)
                    {
                        case "22":
                        case "27":
                        case "29": 
                            Weight = float.Parse(Input.Substring(8));
                            _numbersToDegree = 1000;
                            break;
                        case "23":
                            Weight = float.Parse(Input.Substring(9));
                            _numbersToDegree = 100;
                            break;
                    }

                    switch (CalculatorMode)
                    {
                        case CalculatorMode.Plus:
                            Result += Weight / NumberToDegree;
                            break;
                        case CalculatorMode.Minus:
                            Result -= Weight / NumberToDegree;
                            break;
                    }

                    Input = "";
                }
                else
                {
                    UserDialogs.Instance.Alert("Barcode should contain 13 numbers.");
                    Input = "";
                    return;
                }
            }
            catch (Exception e)
            {
                UserDialogs.Instance.Alert(e.Message);
            }
        }

        private void ResetResult()
        {
            Result = 0;
        }

        //public ICommand ChangeKeyboardVisibilityCommand => new Command<object>(ChangeKeyboardVisibility);

        //private void ChangeKeyboardVisibility(object obj)
        //{
        //    if (IsKeyboardEnabled)
        //        IsKeyboardEnabled = false;
        //    else
        //    {
        //        IsKeyboardEnabled = true;
        //        var entry = obj as Entry;
        //        entry.Focus();
        //    }
        //}

    }
}
