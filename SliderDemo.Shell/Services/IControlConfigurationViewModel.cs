using System;

namespace SliderDemo.Shell.Services
{
    public interface IControlConfigurationViewModel
    {
        IObservable<DialogResult> Result { get; }
    }

    public enum DialogResult
    {
        Accepted,
        Cancelled
    }
}