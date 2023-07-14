using CommunityToolkit.Mvvm.Input;

namespace PrismMauiTest.Errors
{
    public interface ITaskExecutor
    {
        
        // TODO: MAIUI -  AllowMutipleExecutions is gone, make sure you can't spam all buttons?
        AsyncRelayCommand CreateAsyncCommand(Func<Task> execute, Func<bool> canExecute = null);
        // AsyncRelayCommand<T> CreateAsyncCommand<T>(Func<T, Task> execute);
        Task<bool> RunSafeAsync(Func<Task> callback, Func<Exception, Task<bool>> onError = null);
        // Task<bool> RunSafeAsync<T>(Func<T, Task> callback, T t, Func<Exception, Task<bool>> onError = null);
        // Task<bool> RunSafeAsync<T1, T2>(Func<T1, T2, Task> callback, T1 t1, T2 t2, Func<Exception, Task<bool>> onError = null);
        // Task<bool> RunSafeAsync<T1, T2, T3>(Func<T1, T2, T3, Task> callback, T1 t1, T2 t2, T3 t3, Func<Exception, Task<bool>> onError = null);
        // Task<bool> RunSafeInTaskAsync(Func<Task> callback, Func<Exception, Task<bool>> onError);
        // Task<bool> RunSafeInTaskAsync(Func<Task> callback);
        // Task<T> RunSafeInTaskAsync<T>(Func<Task<T>> callback);
        // Task<bool> RunSafeInTaskAsync<T>(Func<T, Task> callback, T t, Func<Exception, Task<bool>> onError = null);
        // Task<bool> RunSafeInTaskAsync<T1, T2>(Func<T1, T2, Task> callback, T1 t1, T2 t2, Func<Exception, Task<bool>> onError = null);
        // Task<bool> RunSafeInTaskAsync<T1, T2, T3>(Func<T1, T2, T3, Task> callback, T1 t1, T2 t2, T3 t3, Func<Exception, Task<bool>> onError = null);
    }
}