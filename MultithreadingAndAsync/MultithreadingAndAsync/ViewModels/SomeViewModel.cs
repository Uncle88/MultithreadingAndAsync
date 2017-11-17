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

        private Command _clickCommandStart;         private Command _clickCommandCount;         private string _outputResult;         private string _outputAdd;         private string _outputCanceled;         private Command _clickCommandCancel;                             int count = 1;          public string OutputCanceled         {             get { return _outputCanceled; }             set             {                 if (value != _outputCanceled)                 {                     _outputCanceled = value;                     OnPropertyChanged();                 }             }         }          public string OutputAdd         {             get { return _outputAdd; }             set             {                 if (value != _outputAdd)                 {                     _outputAdd = value;                     OnPropertyChanged();                 }             }         }          public string OutputResult         {             get { return _outputResult; }             set             {                 if (value != _outputResult)                 {                     _outputResult = value;                     OnPropertyChanged();                 }             }         }          CancellationTokenSource cancelToken = new CancellationTokenSource();          public Command ClickCommandStart         {             get             {                 try                 {                     _clickCommandStart = _clickCommandStart ?? new Command(async() =>                     {                         await Task.Factory.StartNew(async () =>                      {                          await Task.Delay(2000);                             ClicksCountRandom(cancelToken.Token);                      }, cancelToken.Token);                     });                 }                 catch(AggregateException e)                 {                     try                     {                         e.Flatten().Handle(ex => ex is TaskCanceledException);                         OutputCanceled = "Cancelled";                     }                     catch (AggregateException exep)                     {                         OutputCanceled = exep.Message;                     }                     //UIAlertView alert = new UIAlertView()                     //{                     //    Title = "Title",                     //    Message = e.Message,                     //};                 }                 return _clickCommandStart;             }         }          private void ClicksCountRandom(CancellationToken cancellationToken)         {                 count = 0;                 int[] array = new int[10];                 Random rand = new Random();                 for (int i = 0; i < array.Length; i++)                     array[i] = rand.Next(1, 999);                 //Thread.Sleep(5000);                 foreach (var item in array)                 {                     count = item;                 }                 cancellationToken.ThrowIfCancellationRequested();                 OutputResult = (count).ToString();         }          public Command ClickCommandCancel         {             get             {                 return _clickCommandCancel= _clickCommandCancel ?? new Command(() => cancelToken.Cancel(true));             }         }          public Command ClickCommandCount         {             get             {                 return _clickCommandCount = _clickCommandCount ?? new Command(ClicksCountAdd);             }         }          int count2 = 0;         private void ClicksCountAdd()         {             OutputAdd = (count2++).ToString();         } 
    }
}
