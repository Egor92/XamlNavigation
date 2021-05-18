using System;
using System.Collections.Generic;

namespace Egor92.MvvmNavigation.Internal
{
    internal class DataStorage : IDataStorage
    {
        private readonly IDictionary<string, NavigationData> _navigationDataByKey = new Dictionary<string, NavigationData>();

        public void Add(string key, NavigationData navigationData)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (navigationData == null)
            {
                throw new ArgumentNullException(nameof(navigationData));
            }

            _navigationDataByKey[key] = navigationData;
        }

        public bool IsExist(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            return _navigationDataByKey.ContainsKey(key);
        }

        public NavigationData Get(string key)
        {
            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }

            return _navigationDataByKey[key];
        }
    }
}
