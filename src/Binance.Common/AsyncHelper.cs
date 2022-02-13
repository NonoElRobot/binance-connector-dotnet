namespace Binance.Common
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Threading.Tasks;

    internal static class AsyncHelper
    {
        private static readonly TaskFactory MY_TASK_FACTORY = new TaskFactory(
            CancellationToken.None,
            TaskCreationOptions.None,
            TaskContinuationOptions.None,
            TaskScheduler.Default);

        public static TResult RunSync<TResult>(Func<Task<TResult>> func)
        {
            CultureInfo cultureUi = CultureInfo.CurrentUICulture;
            CultureInfo culture = CultureInfo.CurrentCulture;
            return MY_TASK_FACTORY.StartNew(
                () =>
                {
                    Thread.CurrentThread.CurrentCulture = culture;
                    Thread.CurrentThread.CurrentUICulture = cultureUi;
                    return func();
                }).Unwrap().GetAwaiter().GetResult();
        }

        public static void RunSync(Func<Task> func)
        {
            CultureInfo cultureUi = CultureInfo.CurrentUICulture;
            CultureInfo culture = CultureInfo.CurrentCulture;
            MY_TASK_FACTORY.StartNew(
                () =>
                {
                    Thread.CurrentThread.CurrentCulture = culture;
                    Thread.CurrentThread.CurrentUICulture = cultureUi;
                    return func();
                }).Unwrap().GetAwaiter().GetResult();
        }
    }
}