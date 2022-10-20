using System;
namespace XamarinSpectrum.Services
{
    public interface IToastService
    {
        void ShowToast(string message, bool isLongToast = false);
    }
}
