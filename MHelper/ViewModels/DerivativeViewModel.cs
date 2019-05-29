using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using MHelper.Services;
using System.Threading;
using System.Linq.Expressions;
using MHelper.DTO;
using MHelper.State;

namespace MHelper.ViewModels
{
    public class DerivativeViewModel : BaseViewModel
    {
        private string _sourceExpression, _resultExpression;

        private States state;

        public string SourceExpression
        {
            get
            {
                return _sourceExpression;
            }
            set
            {
                _sourceExpression = value;
                OnPropertyChanged("SourceExpression");
            }
        }
        public string ResultExpression
        {
            get
            {
                return _resultExpression;
            }
            set
            {
                _resultExpression = value;
                OnPropertyChanged("ResultExpression");
            }
        }

        public States State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                OnPropertyChanged("State");
            }
        }
    
        public EvaluateRequest Request { get; set; }

        public Command GetDerivativeCommand { get; set; }

        public DerivativeViewModel()
        {
            State = States.Normal;

            Request = new EvaluateRequest
            {
                Expression = SourceExpression,
                Functionality = "Derivative"
            };
            GetDerivativeCommand = new Command(async () => await ExecuteGetDerivativeCommand(Request));
        }

        async Task ExecuteGetDerivativeCommand(EvaluateRequest request)
        {
            State = States.Error;

            var apiService = MHelperApi.GetApiService();

            await apiService.GetDerivative(request).ContinueWith(get =>
            {
                if (get.IsCompleted && get.Status == TaskStatus.RanToCompletion)
                {
                    // Get result and update any UI here.
                    var result = get.Result;
                    ResultExpression = get.Result.LatexDerivative; // For property serialized/deserialized using Newtonsoft.Json
                }
                else if (get.IsFaulted)
                {
                    // If any error occurred exception throws.
                }
                else if (get.IsCanceled)
                {
                    // Task cancelled
                }
            }, TaskScheduler.FromCurrentSynchronizationContext())// execute in main/UI thread.
            .ConfigureAwait(false);// Execute API call on background or worker thread.
        }
    }
   
}
