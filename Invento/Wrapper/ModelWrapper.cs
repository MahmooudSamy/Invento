using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Invento.Wrapper
{
    public class ModelWrapper<T> : NotifayDataErrorBase
    {
        public ModelWrapper(T model)
        {
            Model = model;
        }
        public T Model { get; }

        protected virtual TValue? GetValue<TValue>([CallerMemberName] string? propertyName = null)
        {
            if (propertyName == null) return default;

            PropertyInfo? property = typeof(T).GetProperty(propertyName);
            return property != null ? (TValue?)property.GetValue(Model) : default;
        }
        protected virtual void SetValue<TValue>(TValue value, [CallerMemberName] string? propertyName = null)
        {
            if (propertyName == null) return;

            PropertyInfo? property = typeof(T).GetProperty(propertyName);
            if (property != null)
            {
                property.SetValue(Model, value);
                OnPropertyChanged(propertyName);
                if (value != null)
                {
                    ValidatePropertyInternal(propertyName, value);
                }

            }
        }

        private void ValidatePropertyInternal(string propertyName, object currentValue)
        {
            ClearError(propertyName);
            ValidateDataAnnoutation(propertyName, currentValue);
            ValidateCustomErrors(propertyName);
        }
        private void ValidateDataAnnoutation(string propertyName, object currentValue)
        {


            if (Model != null)
            {
                var context = new ValidationContext(Model) { MemberName = propertyName };
                var results = new List<ValidationResult>();
                Validator.TryValidateProperty(currentValue, context, results);

                foreach (var result in results)
                {
                    if (result.ErrorMessage != null)
                    {
                        AddError(propertyName, result.ErrorMessage);
                    }
                }
            }

        }

        private void ValidateCustomErrors(string propertyName)
        {
            var errors = ValidateProperty(propertyName);
            if (errors != null)
            {
                foreach (var error in errors)
                {
                    AddError(propertyName, error);
                }
            }
        }

        protected virtual IEnumerable<string>? ValidateProperty(string propertyName)
        {
            return null;
        }


    }
}
