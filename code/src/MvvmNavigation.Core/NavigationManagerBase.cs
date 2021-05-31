using System;
using System.Collections.Generic;
using Egor92.MvvmNavigation.Abstractions;
using Egor92.MvvmNavigation.Internal;
using JetBrains.Annotations;

namespace Egor92.MvvmNavigation
{
    public abstract class NavigationManagerBase : INavigationManager
    {
        #region Fields

        private readonly Stack<NavigationHistoryItem> _navigationHistory = new Stack<NavigationHistoryItem>();
        private readonly Navigator _navigator;

        #endregion

        #region Ctor

        protected NavigationManagerBase([NotNull] object frameControl, IViewInteractionStrategy viewInteractionStrategy)
            : this(frameControl, viewInteractionStrategy, new DataStorage())
        {
        }

        protected NavigationManagerBase([NotNull] object frameControl,
                                        IViewInteractionStrategy viewInteractionStrategy,
                                        [NotNull] IDataStorage dataStorage)
        {
            _navigator = new Navigator(frameControl, viewInteractionStrategy, dataStorage);
        }

        #endregion

        #region Navigated

        public event EventHandler<NavigationEventArgs> Navigated;

        private void RaiseNavigated(NavigationEventArgs e)
        {
            Navigated?.Invoke(this, e);
        }

        #endregion

        public void Register([NotNull] string navigationKey, [NotNull] Func<object> getViewModel, [NotNull] Func<object> getView)
        {
            _navigator.Register(navigationKey, getViewModel, getView);
        }

        public bool CanNavigate(string navigationKey)
        {
            return _navigator.CanNavigate(navigationKey);
        }

        public void Navigate(string navigationKey, object arg)
        {
            var navigationResult = _navigator.Navigate(navigationKey, arg);
            var navigationEventArgs = new NavigationEventArgs(navigationResult.View, navigationResult.ViewModel, navigationKey, arg);
            SaveNavigationHistory(navigationResult.ViewModel, navigationResult.View);
            RaiseNavigated(navigationEventArgs);
        }

        private void SaveNavigationHistory(object viewModel, object view)
        {
            _navigationHistory.Push(new NavigationHistoryItem(viewModel, view));
        }

        public void NavigateBack()
        {
            var navigationHistoryItem = _navigationHistory.Pop();
            _navigator.Navigate(navigationHistoryItem.View);
        }
    }
}
