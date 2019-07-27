[![Build status](https://ci.appveyor.com/api/projects/status/28htxgacq2kvbql4?svg=true)](https://ci.appveyor.com/project/Aftnet/applifecycleplugin)
[![NuGet version](https://img.shields.io/nuget/v/Xam.Plugin.AppLifeCycle.svg)](https://www.nuget.org/packages/Xam.Plugin.AppLifeCycle/)

# App Lifecycle Xamarin Plugin

Notify application code as the host application transitions through life cycle states.

Broadly speaking, an application can be in one of four states:

- Active, not suspended: application's window has focus on desktop platforms or is the one on screen on mobile ones.
Application code gets CPU time and app can operate as normal
- Not active, not suspended: application's window loses focus on desktop platforms, a notification or other app view gets drawn over app view.
Application code gets CPU time but it won't be able to get input events and OS may limit some app's functionality (ex. no sound can be played)
- Not active, suspended: usually this happens after application enters not active state, transition is initiated by OS and is invisible to the user
Application does NOT get CPU time, which means no code gets executed. Application state is preserved until OS decides to purge app from memory, which happens without warning.
Application state should be saved before entering this state and resumed in case app is restarted after purging.
- Active, suspended: this cannot happen

# How to use

```
var LifeCycle = Plugin.AppLifeCycle.CrossAppLifecycle.Current;

LifeCycle.Activating += (d,e)=> { Trace.WriteLine($"App activating.); };
LifeCycle.Deactivating += (d, e) => { Trace.WriteLine($"App deactivating."); };
LifeCycle.Resuming += (d, e) => { Trace.WriteLine($"App resuming."); };
LifeCycle.Suspending += (d, e) => { Trace.WriteLine($"App suspending."); };
```

## A note on initialization

Calling `Plugin.AppLifeCycle.CrossAppLifecycle.Current`causes the plugin to try hooking into several platform specific primitives (like App's instance and/or main window).
Doing this too early in application launch may crash as they are not yet initialized, so it's highly recommended to use lazy instantiation for this plugin.

# Extended Execution

By default, UWP apps on Desktop are suspended when the user minimizes their window: this goes against user expectation of being able to minimize apps while waiting fot them to finish ding work.

To get the old behavior, use `IAppLifecycle.RequestExtendedExecutionAsync()`.
Should the call succeed, the app will behave as standard desktop apps do and not be susended when minimized.
Once finished doing work, it's best practice to call `IAppLifecycle.RelinquishExtendedExecution()`.

Windows may at any point revoke an app's extended execution privilege (device unplugged from mains, users manually revoking privilege are two main culprits).
The `ExtendedExecutionAllowedChanged` notifies of such occurrences.