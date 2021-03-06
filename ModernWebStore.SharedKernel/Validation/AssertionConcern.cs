﻿using ModernWebStore.SharedKernel.Events;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ModernWebStore.SharedKernel.Validation
{
    public static class AssertionConcern
    {
        public static bool IsValid(params DomainNotification[] validations)
        {
            var notificationsNotNull = validations.Where(validation => validation != null);
            NotifyAll(notificationsNotNull);

            return notificationsNotNull.Count().Equals(0);
        }

        private static void NotifyAll(IEnumerable<DomainNotification> notifications)
        {
            notifications.ToList().ForEach(validation =>
            {
                DomainEvent.Raise<DomainNotification>(validation);
            });
        }

        public static DomainNotification AssertLength(string stringValue, int minimum, int maximum, string message)
            => (stringValue.Trim().Length < minimum || stringValue.Trim().Length > maximum) ? new DomainNotification("AssertArgumentLength", message) : null;

        public static DomainNotification AssertMatches(string pattern, string stringValue, string message)
            => (!new Regex(pattern).IsMatch(stringValue)) ? new DomainNotification("AssertArgumentLength", message) : null;

        public static DomainNotification AssertNotEmpty(string stringValue, string message)
            => (string.IsNullOrEmpty(stringValue)) ? new DomainNotification("AssertArgumentNotEmpty", message) : null;

        public static DomainNotification AssertNotNull(object object1, string message)
            => (object1 == null) ? new DomainNotification("AssertArgumentNotNull", message) : null;

        public static DomainNotification AssertTrue(bool boolValue, string message)
            => (!boolValue) ? new DomainNotification("AssertArgumentTrue", message) : null;

        public static DomainNotification AssertAreEquals(string value, string match, string message)
            => (!(value == match)) ? new DomainNotification("AssertArgumentTrue", message) : null;

        public static DomainNotification AssertIsGreaterThan(int value1, int value2, string message)
            => (!(value1 > value2)) ? new DomainNotification("AssertArgumentTrue", message) : null;

        public static DomainNotification AssertIsGreaterThan(decimal value1, decimal value2, string message)
            => (!(value1 > value2)) ? new DomainNotification("AssertArgumentTrue", message) : null;

        public static DomainNotification AssertIsGreaterOrEqualThan(int value1, int value2, string message)
            => (!(value1 >= value2)) ? new DomainNotification("AssertArgumentTrue", message) : null;
    }
}
