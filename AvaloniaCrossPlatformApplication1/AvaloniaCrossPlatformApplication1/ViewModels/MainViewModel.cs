using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;

namespace AvaloniaCrossPlatformApplication1.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<DataViewModel> Items { get; } = new();

        public ReactiveCommand<Unit, Unit> AddItemsCommand { get; }
        public ReactiveCommand<Unit, Unit> RemoveItemsCommand { get; }

        public MainViewModel()
        {
            for (var i = 0; i != 200; ++i)
                Items.Add(new DataViewModel { Index = Items.Count });

            AddItemsCommand = ReactiveCommand.Create(() =>
                {
                    for (var i = 0; i != 10; ++i)
                        Items.Add(new DataViewModel { Index = Items.Count });
                }
            );

            RemoveItemsCommand = ReactiveCommand.Create(() =>
                {
                    for (var i = 0; i != 10; ++i)
                        Items.RemoveAt(Items.Count - 1);
                }
            );
        }
    }

    public class DataViewModel : ViewModelBase
    {
        public int Index
        {
            set
            {
                this.RaiseAndSetIfChanged(ref index, value);
                this.RaisePropertyChanged(nameof(IsOver100));
                this.RaisePropertyChanged(nameof(IsUnder100));
            }

            get => index;
        }

        public int index;

        public bool IsOver100 => Index > 100;
        public bool IsUnder100 => !IsOver100;
    }
}