using System;
using JetBrains.Annotations;

namespace Egor92.MvvmNavigation.Internal
{
    public sealed class NavigationHistoryItem
    {
        public NavigationHistoryItem([NotNull] object viewModel, [NotNull] object view)
        {
            ViewModel = viewModel ?? throw new ArgumentNullException(nameof(viewModel));
            View = view ?? throw new ArgumentNullException(nameof(view));
        }

        public object ViewModel { get; }

        public object View { get; }
    }
}