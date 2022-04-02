using Microsoft.Xaml.Behaviors.Core;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace BaseConverter.ViewModels
{
    public class ConverterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand TBGotFocusCommand => new ActionCommand((sender) => ExecuteGotFocus((string)sender));

        public ICommand TBLostFocusCommand => new ActionCommand((sender) => ExecuteLostFocus((string)sender));

        private void ExecuteGotFocus(string sender)
        {
            if (sender == "TBDecimal") _hasTBDecimalFocus = true;
            else if (sender == "TBBinary") _hasTBBinaryFocus = true;
            else if (sender == "TBOctal") _hasTBOctalFocus = true;
            else if (sender == "TBHexadecimal") _hasTBHexadecimalFocus = true;
        }

        private void ExecuteLostFocus(string sender)
        {
            if (sender == "TBDecimal") _hasTBDecimalFocus = false;
            else if (sender == "TBBinary") _hasTBBinaryFocus = false;
            else if (sender == "TBOctal") _hasTBOctalFocus = false;
            else if (sender == "TBHexadecimal") _hasTBHexadecimalFocus = false;
        }

        private readonly Models.ConverterModel converterModel;

        public ConverterViewModel()
        {
            converterModel = new Models.ConverterModel();
        }

        Models.ConverterModel.ConverterStruct converterStruct;

        private string _decimalNumber = "";
        private string _binaryNumber = "";
        private string _octalNumber = "";
        private string _hexadecimalNumber = "";

        private bool _hasTBDecimalFocus = false;
        private bool _hasTBBinaryFocus = false;
        private bool _hasTBOctalFocus = false;
        private bool _hasTBHexadecimalFocus = false;

        private readonly string errorString = "Falsche Eingabe!";

        private void SetTextBoxText(string senderName, string text)
        {
            if (_hasTBDecimalFocus == false) DecimalNumber = text;
            if (_hasTBBinaryFocus == false) BinaryNumber = text;
            if (_hasTBOctalFocus == false) OctalNumber = text;
            if (_hasTBHexadecimalFocus == false) HexadecimalNumber = text;
        }

        public string DecimalNumber
        {
            get => _decimalNumber;
            set
            {
                _decimalNumber = value;
                OnPropertyChanged();
                if (_hasTBDecimalFocus)
                {
                    if (_decimalNumber != "")
                    {
                        try
                        {
                            converterStruct = converterModel.DecimalToBinary(_decimalNumber);
                            if (converterStruct.isValid)
                            {
                                BinaryNumber = converterStruct.numberString;
                            }
                            else
                            {
                                this.SetTextBoxText("TBDecimal", errorString);
                            }
                            converterStruct = converterModel.DecimalToOctal(_decimalNumber);
                            if (converterStruct.isValid)
                            {
                                OctalNumber = converterStruct.numberString;
                            }
                            else
                            {
                                this.SetTextBoxText("TBDecimal", errorString);
                            }
                            converterStruct = converterModel.DecimalToHexadecimal(_decimalNumber);
                            if (converterStruct.isValid)
                            {
                                HexadecimalNumber = converterStruct.numberString;
                            }
                            else
                            {
                                this.SetTextBoxText("TBDecimal", errorString);
                            }
                        }
                        catch
                        {
                            this.SetTextBoxText("TBDecimal", errorString);
                        }
                    }
                    else
                    {
                        BinaryNumber = "";
                        OctalNumber = "";
                        HexadecimalNumber = "";
                    }
                }
                else
                {
                    if (_decimalNumber != "")
                    {
                        if (_hasTBBinaryFocus == false)
                        {
                            converterStruct = converterModel.DecimalToBinary(_decimalNumber);
                            BinaryNumber = converterStruct.numberString;
                        }
                        if (_hasTBOctalFocus == false)
                        {
                            converterStruct = converterModel.DecimalToOctal(_decimalNumber);
                            OctalNumber = converterStruct.numberString;
                        }
                        if (_hasTBHexadecimalFocus == false)
                        {
                            converterStruct = converterModel.DecimalToHexadecimal(_decimalNumber);
                            HexadecimalNumber = converterStruct.numberString;
                        }
                    }
                }
            }
        }

        public string BinaryNumber
        {
            get => _binaryNumber;
            set
            {
                _binaryNumber = value;
                OnPropertyChanged();
                if (_hasTBBinaryFocus)
                {
                    if (_binaryNumber != "")
                    {
                        try
                        {
                            converterStruct = converterModel.BinaryToDecimal(_binaryNumber);
                            if (converterStruct.isValid)
                            {
                                DecimalNumber = converterStruct.numberString;
                            }
                            else
                            {
                                this.SetTextBoxText("TBBinary", errorString);
                            }
                        }
                        catch
                        {
                            this.SetTextBoxText("TBBinary", errorString);
                        }
                    }
                    else
                    {
                        DecimalNumber = "";
                        OctalNumber = "";
                        HexadecimalNumber = "";
                    }
                }
            }
        }

        public string OctalNumber
        {
            get => _octalNumber;
            set
            {
                _octalNumber = value;
                OnPropertyChanged();
                if (_hasTBOctalFocus)
                {
                    if (_octalNumber != "")
                    {
                        try
                        {
                            converterStruct = converterModel.OctalToDecimal(_octalNumber);
                            if (converterStruct.isValid)
                            {
                                DecimalNumber = converterStruct.numberString;
                            }
                            else
                            {
                                this.SetTextBoxText("TBOctal", errorString);
                            }
                        }
                        catch
                        {
                            this.SetTextBoxText("TBOctal", errorString);
                        }
                    }
                    else
                    {
                        DecimalNumber = "";
                        BinaryNumber = "";
                        HexadecimalNumber = "";
                    }
                }
            }
        }

        public string HexadecimalNumber
        {
            get => _hexadecimalNumber;
            set
            {
                _hexadecimalNumber = value;
                OnPropertyChanged();
                if (_hasTBHexadecimalFocus)
                {
                    if (HexadecimalNumber != "")
                    {
                        try
                        {
                            converterStruct = converterModel.HexadecimalToDecimal(_hexadecimalNumber);
                            if (converterStruct.isValid)
                            {
                                DecimalNumber = converterStruct.numberString;
                            }
                            else
                            {
                                this.SetTextBoxText("TBHexadecimal", errorString);
                            }
                        }
                        catch
                        {
                            this.SetTextBoxText("TBHexadecimal", errorString);
                        }
                    }
                    else
                    {
                        DecimalNumber = "";
                        BinaryNumber = "";
                        OctalNumber = "";
                    }
                }
            }
        }
    }
}
