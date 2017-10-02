using System.Threading.Tasks;

namespace Nutrimeal.Common
{
    public class AsyncUtils
    {
        private static Task _completedTask;

        public static Task CompletedTaskAsync()
        {
            return _completedTask ?? InitCompletedTaskAsync();
        }

        public static Task<T> FromResultAsync<T>(T result)
        {
            var tcs = new TaskCompletionSource<T>();
            tcs.SetResult(result);
            return tcs.Task;
        }

        private static Task InitCompletedTaskAsync()
        {
            var tcs = new TaskCompletionSource<object>();
            tcs.SetResult(null);
            _completedTask = tcs.Task;
            return _completedTask;
        }
    }
}