using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Blauhaus.Common.Utils.NotifyPropertyChanged
{
    public abstract class BaseBindableObject : INotifyPropertyChanged
    {
        private static readonly object Locker = new object();
        private Dictionary<string, object>? _properties;
        protected Dictionary<string, object> Properties => _properties ??= new Dictionary<string, object>();

        protected void InitiazeValue(string propertyName, object value)
        {
            lock (Locker)
            {
                Properties[propertyName] = value;
            }
        }

        protected bool SetProperty<T>(T value, [CallerMemberName] string propertyName = "")
        {
            if (Properties.TryGetValue(propertyName, out object val))
            {
                if (EqualityComparer<T>.Default.Equals((T)val, value))
                    return false;
            }

            Properties[propertyName] = value;
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            return true;
        }

        protected bool SetProperty<T>(T value,  Action onChanged, [CallerMemberName] string propertyName = "")
        {
            if (Properties.TryGetValue(propertyName, out object val))
            {
                if (EqualityComparer<T>.Default.Equals((T)val, value))
                    return false;
            }
            lock (Locker)
            {
                Properties[propertyName] = value;
            }
            onChanged?.Invoke();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }

        protected T GetProperty<T>(T defaultValue = default, [CallerMemberName] string propertyName = "")
        { 
            if (Properties.TryGetValue(propertyName, out var val))
                return (T)val;
            return defaultValue;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    }
}