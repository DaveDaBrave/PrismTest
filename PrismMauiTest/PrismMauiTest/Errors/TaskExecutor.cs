using CommunityToolkit.Mvvm.Input;

namespace PrismMauiTest.Errors
{
    public class TaskExecutor : ITaskExecutor
    {
        public TaskExecutor() { }

        public AsyncRelayCommand CreateAsyncCommand(Func<Task> execute, Func<bool> canExecute = null)
        {
            canExecute ??= () => true;

            return new AsyncRelayCommand(async () => await RunSafeAsync(execute), canExecute);
        }

        public async Task<bool> RunSafeAsync(Func<Task> callback, Func<Exception, Task<bool>> onError = null)
        {
            try
            {
                await callback();

                return true;
            }
            catch (Exception e)
            {
                // TODO MAUI _logger.Error(this, "Error on task execution!", e);
                return false;
            }
        }
    }
}