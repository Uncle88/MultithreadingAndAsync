using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace MultithreadingAndAsync.ViewModels
{
    public class SomeViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //private Command _clickCommandStart;
        //private Command _clickCommandCancel;
        private string _outputResult;

        public string OutputResult
        {
            get { return _outputResult; }
            set
            {
                if (value != _outputResult)
                {
                    _outputResult = value;
                    OnPropertyChanged();
                }
            }
        }

        public Command ClickCommandStart
        {
            get
            {
                return null;
            }
        }

        public Command ClickCommandCancel
        {
            get
            {
                return null;
            }
        }
    }
}
