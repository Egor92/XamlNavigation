using System;
using Egor92.MvvmNavigation.Abstractions;

namespace Egor92.MvvmNavigation.Unity.UnitTests.Internal.Types
{
    internal class NavigationManager : INavigationManager
    {
        public bool CanNavigate(string navigationKey)
        {
            throw new NotImplementedException();
        }

        public void Navigate(string navigationKey, object arg)
        {
            throw new NotImplementedException();
        }

        public void NavigateBack()
        {
            throw new NotImplementedException();
        }

#pragma warning disable 67
        public event EventHandler<NavigationEventArgs> Navigated;
#pragma warning restore 67
    }
}
