using System;
using System.Collections.Generic;
using System.Text;
using ReactiveUI;

namespace lab4.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public string _expression = "";
        public ReactiveCommand<string, string> OnClickCommand { get; }
        public MainWindowViewModel()
        {
            OnClickCommand = ReactiveCommand.Create<string, string>((str) => Expression = str);
        }
        public string Expression
        {
            set
            {
                if (_expression == "Error")
                {
                    _expression = "";
                }
                if (value != "=")
                {
                    this.RaiseAndSetIfChanged(ref _expression, _expression + value);
                }
                else
                {
                    try
                    {
                        if (_expression.IndexOf("+") == 0 || _expression.IndexOf("+") == _expression.Length - 1 ||
                            _expression.IndexOf("-") == 0 || _expression.IndexOf("-") == _expression.Length - 1 ||
                            _expression.IndexOf("*") == 0 || _expression.IndexOf("*") == _expression.Length - 1 ||
                            _expression.IndexOf("/") == 0 || _expression.IndexOf("/") == _expression.Length - 1)
                        {
                            throw new lab_1.ex.RomanNumberException("Invalid input");
                        }
                        if (_expression.IndexOf("+") != -1)
                        {
                            Models.RomanNumberExtend a = new(_expression.Substring(0, _expression.IndexOf("+")));
                            Models.RomanNumberExtend b = new(_expression.Substring(_expression.IndexOf("+")));
                            this.RaiseAndSetIfChanged(ref _expression, (a + b).ToString());
                        }
                        if (_expression.IndexOf("*") != -1)
                        {
                            Models.RomanNumberExtend a = new(_expression.Substring(0, _expression.IndexOf("*")));
                            Models.RomanNumberExtend b = new(_expression.Substring(_expression.IndexOf("*")));
                            this.RaiseAndSetIfChanged(ref _expression, (a * b).ToString());
                        }
                        if (_expression.IndexOf("-") != -1)
                        {
                            Models.RomanNumberExtend a = new(_expression.Substring(0, _expression.IndexOf("-")));
                            Models.RomanNumberExtend b = new(_expression.Substring(_expression.IndexOf("-")));
                            this.RaiseAndSetIfChanged(ref _expression, (a - b).ToString());
                        }
                        if (_expression.IndexOf("/") != -1)
                        {
                            Models.RomanNumberExtend a = new(_expression.Substring(0, _expression.IndexOf("/")));
                            Models.RomanNumberExtend b = new(_expression.Substring(_expression.IndexOf("/")));
                            this.RaiseAndSetIfChanged(ref _expression, (a / b).ToString());
                        }
                        _expression = "";
                    }
                    catch(lab_1.ex.RomanNumberException)
                    {
                        this.RaiseAndSetIfChanged(ref _expression, "Error");
                    }
                }
            }
            get
            {
                return _expression;
            }
        }
    }
}
