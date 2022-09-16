using Avalonia.Controls;
using Avalonia.Controls.Templates;
using AvaloniaCrossPlatformApplication1.ViewModels;
using System;

namespace AvaloniaCrossPlatformApplication1.Views
{
    public class DataTemplateSelector : IDataTemplate
    {
        public IDataTemplate? Over100DataTemplate { get; set; }
        public IDataTemplate? Under100DataTemplate { get; set; }

        public IControl? Build(object? param)
        {
            if (param is not DataViewModel vm)
                throw new NotSupportedException();

            return vm.IsOver100
                ? Over100DataTemplate?.Build(param)
                : Under100DataTemplate?.Build(param);
        }

        public bool Match(object? data)
        {
            return data is DataViewModel;
        }
    }
}