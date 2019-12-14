﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using Blauhaus.Common.Utils.Extensions;
using HotChocolate.Execution;
using NUnit.Framework;

namespace Blauhaus.Common.TestHelpers.Hotchocolate.Extensions
{
    public static class OrderedDictionaryExtensions
    {
        
        public static object GetProperty<T>(this OrderedDictionary orderedDictionary, Expression<Func<T, object>> expression)
        {
            return orderedDictionary.GetProperty(expression.ToPropertyName());
        }


        public static object GetProperty(this OrderedDictionary orderedDictionary, string propertyName)
        {
            var index = -1;
            var foundKey=false;
            
            foreach (var key in orderedDictionary.Keys)
            {
                index++;
                if (key == propertyName)
                {
                    foundKey = true;
                    break;
                }
            }

            if(!foundKey)
                Assert.Fail($"The key {propertyName} was not found");

            return  orderedDictionary.Values.ToArray()[index];
        }
        
        public static void VerifyProperty<T, TProperty>(this OrderedDictionary orderedDictionary, Expression<Func<T, TProperty>>  expression, TProperty propertyValue)
        {
            var propertyName = expression.ToPropertyName();
            var property = orderedDictionary.GetProperty(propertyName);

            if(typeof(TProperty) == typeof(Guid?))
            {
                Assert.That( Guid.Parse(property.ToString()), Is.EqualTo(propertyValue));
            }
            else
            {
                Assert.That(property, Is.EqualTo(propertyValue));
            }
        }

        public static void VerifyPropertyDateTime(
            this OrderedDictionary orderedDictionary,
            string propertyName,
            DateTime? propertyValue)
        {
            Assert.That((string) orderedDictionary.GetProperty(propertyName), Is.EqualTo(propertyValue?.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffZ", CultureInfo.InvariantCulture)));
        }

        public static void VerifyProperty(this OrderedDictionary orderedDictionary,  string propertyName, object propertyValue)
        {
            var property = orderedDictionary.GetProperty(propertyName);
            Assert.That(property, Is.EqualTo(propertyValue));
        }
        
        public static void VerifyPropertyDateTimeOffset(this OrderedDictionary orderedDictionary,  string propertyName, DateTimeOffset propertyValue)
        {
            var objectProperty = (string)orderedDictionary.GetProperty(propertyName);
            Assert.That(objectProperty, Is.EqualTo(propertyValue.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffZ", CultureInfo.InvariantCulture)));
        }

        public static void VerifyPropertyDateTime(this OrderedDictionary orderedDictionary,  string propertyName, DateTime propertyValue)
        {
            var objectProperty = (string)orderedDictionary.GetProperty(propertyName);
            Assert.That(objectProperty, Is.EqualTo(propertyValue.ToString("yyyy-MM-ddTHH\\:mm\\:ss.fffZ", CultureInfo.InvariantCulture)));
        }

        public static void VerifyPropertyGuid(this OrderedDictionary orderedDictionary,  string propertyName, Guid propertyValue)
        {
            var objectProperty = (string)orderedDictionary.GetProperty(propertyName);
            Assert.That(Guid.Parse(objectProperty), Is.EqualTo(propertyValue));
        }

        public static OrderedDictionary FindById(this List<OrderedDictionary> orderedDictionaries, Guid propertyValue)
        {
            var propertyName = "Id";
            return orderedDictionaries.FindByKey(propertyName, propertyValue,  x => Guid.Parse(x.ToString()));
        }

        public static OrderedDictionary FindByGuidKey<T>(this List<OrderedDictionary> orderedDictionaries, Expression<Func<T, Guid>> expression, Guid propertyValue)
        {
            var propertyName = expression.ToPropertyName();
            return orderedDictionaries.FindByKey(propertyName, propertyValue, x => Guid.Parse(x.ToString()));
        }

        public static OrderedDictionary FindByKey<T>(this List<OrderedDictionary> orderedDictionaries, string propertyName, T propertyValue, Func<object, T> converter)
        {
            var dictionaryindex = -1;
            var foundKey = false;

            foreach (var dictionary in orderedDictionaries)
            {

                if (foundKey)
                    break;

                dictionaryindex++;
                foreach (var _ in dictionary.Keys)
                {
                    if (dictionary.TryGetValue(propertyName, out var dictionaryValue))
                    {
                        if (converter.Invoke(dictionaryValue).Equals(propertyValue))
                        {
                            foundKey = true;
                            break;
                        }
                        
                    }
                }
            }

            if (!foundKey)
                Assert.Fail($"The key {propertyName} was not found");

            return orderedDictionaries[dictionaryindex];
        }


    }
}