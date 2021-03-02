using System.Reactive;
using System.Reactive.Linq;
using ReactiveUI;
using SliderDemo.Shell.Services;

namespace SliderDemo.Shell.ViewModels.Slider
{
    public class SliderViewModel : ReactiveObject
    {
        private readonly ObservableAsPropertyHelper<bool> _isEditable;
        private readonly ObservableAsPropertyHelper<string> _outputValueString;

        private double _maxValue;
        private double _minValue;
        private string _name;

        private int _precision;

        private NumberRounding _rounding;
        private double _userValue;

        public SliderViewModel(
            SliderConfiguration Configuration,
            IControlTuningService<SliderConfiguration> TuningService)
        {
            this.Configuration = Configuration;

            this.WhenAnyValue(x => x.UserValue,
                              x => x.Precision,
                              (v, p) => v.ToString("F" + p))
                .ToProperty(this, x => x.OutputValueString, out _outputValueString);

            Tune = ReactiveCommand.CreateFromTask(() => TuningService.Tune(this.Configuration));
            Tune.ObserveOnDispatcher()
                .BindTo(this, x => x.Configuration);

            Tune.IsExecuting
                .Select(x => !x)
                .ToProperty(this, x => x.IsEditable, out _isEditable);
        }

        public ReactiveCommand<Unit, SliderConfiguration> Tune { get; }

        private SliderConfiguration Configuration
        {
            get => new()
            {
                Name      = Name,
                Minimum   = MinValue,
                Maximum   = MaxValue,
                Precision = Precision,
                Rounding  = Rounding,
                Value     = UserValue
            };
            set
            {
                Name      = value.Name;
                Precision = value.Precision;
                MinValue  = value.Minimum;
                MaxValue  = value.Maximum;
                UserValue = value.Value;
                Rounding  = value.Rounding;
            }
        }

        public string OutputValueString => _outputValueString.Value;

        public bool IsEditable => _isEditable.Value;

        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
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

        public int Precision
        {
            get => _precision;
            set => this.RaiseAndSetIfChanged(ref _precision, value);
        }

        public NumberRounding Rounding
        {
            get => _rounding;
            set => this.RaiseAndSetIfChanged(ref _rounding, value);
        }
    }
}