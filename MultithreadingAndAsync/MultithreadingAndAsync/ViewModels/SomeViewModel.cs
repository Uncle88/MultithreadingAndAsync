using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
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

        private Command _clickCommandStart;         private Command _clickCommandCount;         private string _outputResult;         private string _outputAdd;         private string _outputCanceled;         private Command _clickCommandCancel;                             int count = 1;
        int count2 = 0;

        CancellationTokenSource cts;          public string OutputCanceled         {             get { return _outputCanceled; }             set             {                 if (value != _outputCanceled)                 {                     _outputCanceled = value;                     OnPropertyChanged();                 }             }         }          public string OutputAdd         {             get { return _outputAdd; }             set             {                 if (value != _outputAdd)                 {                     _outputAdd = value;                     OnPropertyChanged();                 }             }         }          public string OutputResult         {             get { return _outputResult; }             set             {                 if (value != _outputResult)                 {                     _outputResult = value;                     OnPropertyChanged();                 }             }         }          public Command ClickCommandStart         {             get             {
                cts = new CancellationTokenSource();                 try                 {                     _clickCommandStart = _clickCommandStart ?? new Command(async () =>                     {
                        await Task.Delay(5000);
                        var task = Task.Run(() => ClicksCountRandom(cts.Token), cts.Token);                      });                 }                 catch (AggregateException e)                 {
                    OutputCanceled = e.Message;                 }                 return _clickCommandStart;             }         }          private void ClicksCountRandom(CancellationToken cancellationToken)         {                 count = 0;                 int[] array = new int[10];                 Random rand = new Random();                 for (int i = 0; i < array.Length; i++)                     array[i] = rand.Next(1, 999);                 foreach (var item in array)                 {                     count = item;
                cancellationToken.ThrowIfCancellationRequested();                 }                 OutputResult = (count).ToString();         }          public Command ClickCommandCancel         {             get             {                 return _clickCommandCancel= _clickCommandCancel ?? new Command(() => Cancel());             }         }

        private void Cancel()
        {
            cts.Cancel();
            OutputCanceled = "Cancelled";
        }          public Command ClickCommandCount         {             get             {                 return _clickCommandCount = _clickCommandCount ?? new Command(ClicksCountAdd);             }         }          private void ClicksCountAdd()         {             OutputAdd = (count2++).ToString();         }
    }
}
