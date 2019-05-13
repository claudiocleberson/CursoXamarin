﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace TravelRecord.ViewModel.Convertes
{
    public class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;

            
            DateTimeOffset dateTime = (DateTimeOffset)value;
            DateTimeOffset rightNow = DateTimeOffset.Now;

            var difference = rightNow - dateTime;

            if (difference.TotalDays > 1)
                return $"{dateTime:d}";
            else
            {
                if (difference.TotalSeconds < 60)
                    return $"{ difference.TotalSeconds:0} seconds ago";
                else if (difference.TotalMinutes < 60)
                    return $"{difference.TotalMinutes:0} minutes ago";
                else if (difference.TotalHours < 24)
                    return $"{difference.TotalHours:0} hours ago";

                return "yesterday";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DateTimeOffset.Now;
        }
    }
}
