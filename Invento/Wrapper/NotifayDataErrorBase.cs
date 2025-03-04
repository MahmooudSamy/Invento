using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invento.Wrapper
{
    public class NotifayDataErrorBase : ViewModelBase, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _errorsByPropertyName = new();



        public bool HasErrors => _errorsByPropertyName.Any();

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public IEnumerable GetErrors(string? propertyName)
        {
            if (propertyName == null)
            {
                return _errorsByPropertyName.Values.SelectMany(x => x);
            }

            if (_errorsByPropertyName.TryGetValue(propertyName, out var errors))
            {
                return errors;
            }

            return Enumerable.Empty<string>();
        }

        protected virtual void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
            base.OnPropertyChanged(nameof(HasErrors));
        }


        protected void AddError(string propertyName, string error)
        {
            if (!_errorsByPropertyName.TryGetValue(propertyName, out var errors))
            {
                _errorsByPropertyName[propertyName] = new List<string>();
            }

            if (!_errorsByPropertyName[propertyName].Contains(error))
            {
                _errorsByPropertyName[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }

        protected void ClearError(string propertyName)
        {
            if (_errorsByPropertyName.Remove(propertyName))
            {
                OnErrorsChanged(propertyName);
            }
        }

    }
}
