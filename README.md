
# UINavigation

[![Build status](https://img.shields.io/appveyor/ci/Egor92/UINavigation/master)](https://ci.appveyor.com/project/Egor92/UINavigation/branch/master)
[![Version](https://img.shields.io/nuget/vpre/UINavigation.Wpf.svg)](https://www.nuget.org/packages/UINavigation.Wpf)
[![Downloads](https://img.shields.io/nuget/dt/UINavigation.Wpf.svg)](https://www.nuget.org/packages/UINavigation.Wpf)
[![GitHub contributors](https://img.shields.io/github/contributors/Egor92/UINavigation.svg)](https://github.com/Egor92/UINavigation/graphs/contributors)
[![License](https://img.shields.io/github/license/Egor92/UINavigation.svg)](https://github.com/Egor92/UINavigation/blob/master/LICENSE)
[![Join the Gitter chat!](https://badges.gitter.im/Egor92/UINavigation.svg)](https://gitter.im/UINavigation/community?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

Перейти на [русскую страницу](https://github.com/Egor92/UINavigation/blob/master/README.RUS.md)

This library allows you to adjust navigation behavior in your WPF application and implement ViewModel-based navigation. This library completely adhere to MVVM pattern.

## How to use it

1. Install NuGet package [UINavigation.Wpf](https://www.nuget.org/packages/UINavigation.Wpf/ "UINavigation.Wpf")
1. Use the following code in your project:

```csharp
//1. Create navigation manager
var navigationManager = new NavigationManager(window);

//2. Register set of navigation key, view and viewmodel
navigationManager.Register<FirstView>(NavigationKeys.First, () => new FirstViewModel());
navigationManager.Register<SecondView>(NavigationKeys.Second, () => new SecondViewModel());

//3. In any place call Navigate method in order to switch UI
navigationManager.Navigate(NavigationKeys.First);
```

This code should be placed in composition root. It is **App.OnStartup** method usually:

```csharp
public partial class App : Application
{
	protected override void OnStartup(StartupEventArgs e)
	{
		var window = new MainWindow();
		var navigationManager = new NavigationManager(window);

		navigationManager.Register<FirstView>(NavigationKeys.First, () => new FirstViewModel());
		navigationManager.Register<SecondView>(NavigationKeys.Second, () => new SecondViewModel());

		navigationManager.Navigate(NavigationKeys.First);
		window.Show();
	}
}
```
