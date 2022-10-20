using System;
using Android.Widget;
using Xamarin.Forms;
using XamarinSpectrum.Services;

namespace XamarinSpectrum.Droid.Services
{
    public class ToastService : IToastService
    {
        private static Toast _toastInstance;

        public void ShowToast(string message, bool isLongToast = false)
        {
            var toastLength = isLongToast
                ? ToastLength.Long
                : ToastLength.Short;

            Device.BeginInvokeOnMainThread(() =>
            {
                _toastInstance?.Cancel();
                _toastInstance = Toast.MakeText(Android.App.Application.Context,
                    message, toastLength);
                _toastInstance?.Show();
            });
        }
    }
}
