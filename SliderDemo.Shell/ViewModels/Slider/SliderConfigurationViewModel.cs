using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;
using SliderDemo.Shell.Services;

namespace SliderDemo.Shell.ViewModels.Slider
{
    public class SliderConfigurationViewModel : ReactiveObject, IControlConfigurationViewModel, IDisposable
    {
        private readonly ObservableAsPropertyHelper<bool> _boundingError;
        private readonly CompositeDisposable _cleanup = new();
        private readonly ObservableAsPropertyHelper<int> _precision;
        private readonly ObservableAsPropertyHelper<bool> _userValueError;
        private string _customName;

        private int _digits;
        private double _maxValue;
        private double _minValue;

        private NumberRounding _selectedRounding;

        private double _userValue;

        public SliderConfigurationViewModel()
        {
            _customName = string.Empty;
            _minValue   = 0;
            _maxValue   = 1;

            // Rounding
            Roundings = Enum.GetValues(typeof(NumberRounding))
                            .OfType<NumberRounding>()
                            .ToList();
            _selectedRounding = Roundings.First();

            this.WhenAnyValue(x => x.SelectedRounding,
                              x => x.Digits,
                              (r, d) => r switch
                              {
                                  NumberRounding.Natural => 0,
                                  NumberRounding.Real => d,
                                  _ => throw new ArgumentException($"Unknown number rounding type: {r}")
                              })
                .ToProperty(this, x => x.Precision, out _precision);

            // Value corrections
            ValueCorrection(x => x.UserValue).DisposeWith(_cleanup);
            ValueCorrection(x => x.MinValue).DisposeWith(_cleanup);
            ValueCorrection(x => x.MaxValue).DisposeWith(_cleanup);

            // Bounding checks
            this.WhenAnyValue(x => x.MaxValue,
                              x => x.MinValue,
                              x => x.UserValue,
                              (min, max, user) => user < min || user > max)
                .ToProperty(this, x => x.UserValueError, out _userValueError)
                .DisposeWith(_cleanup);

            this.WhenAnyValue(x => x.MinValue,
                              x => x.MaxValue,
                              (min, max) => max < min)
                .ToProperty(this, x => x.BoundingError, out _boundingError)
                .DisposeWith(_cleanup);

            Cancel = ReactiveCommand.Create(() => { });
            Accept = ReactiveCommand.Create(() => { });
        }

        public ReactiveCommand<Unit, Unit> Accept { get; }
        public ReactiveCommand<Unit, Unit> Cancel { get; }

        public int Precision => _precision.Value;

        public IList<NumberRounding> Roundings { get; }

        public bool BoundingError  => _boundingError.Value;
        public bool UserValueError => _userValueError.Value;

        public int Digits
        {
            get => _digits;
            set => this.RaiseAndSetIfChanged(ref _digits, value);
        }

        public NumberRounding SelectedRounding
        {
            get => _selectedRounding;
            set => this.RaiseAndSetIfChanged(ref _selectedRounding, value);
        }

        public string CustomName
        {
            get => _customName;
            set => this.RaiseAndSetIfChanged(ref _customName, value);
        }

        public double UserValue
        {
            get => _userValue;
            set => this.RaiseAndSetIfChanged(ref _userValue, value);
        }

        public double MinValue
        {
            get => _minValue;
            set => this.RaiseAndSetIfChanged(ref _minValue, value);
        }

        public double MaxValue
        {
            get => _maxValue;
            set => this.RaiseAndSetIfChanged(ref _maxValue, value);
        }

        // ReSharper disable once InvokeAsExtensionMethod
        public IObservable<DialogResult> Result => Observable.Merge(Accept.Select(_ => DialogResult.Accepted),
                                                                    Cancel.Select(_ => DialogResult.Cancelled));

        public void Dispose()
        {
            _cleanup.Dispose();
        }

        private IDisposable ValueCorrection(Expression<Func<SliderConfigurationViewModel, double>> Property)
        {
            return this.WhenAnyValue(Property, x => x.Precision, Math.Round)
                       .BindTo(this, Property);
        }
    }

    public enum NumberRounding
    {
        [Description("ℤ")] Natural,
        [Description("ℚ")] Real
    }
}