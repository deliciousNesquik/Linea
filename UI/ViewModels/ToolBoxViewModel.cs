using System;
using System.Collections.Generic;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Linea.Core.Services;
using Control = Linea.Core.Models.Control;

namespace Linea.UI.ViewModels;

public partial class ToolBoxViewModel : ViewModelBase
{
    [ObservableProperty] private List<Control> _allControlsList;
    [ObservableProperty] private Control _selectedControl;

    public ToolBoxViewModel()
    {
        AllControlsList = new ControlMetadata().LoadControls("Core/Metadata/controls.json");
        SelectedControl = null!;
    }

    partial void OnSelectedControlChanged(Control value)
    {
        Console.WriteLine($"User selected control: {value.Name}");
    }

    [RelayCommand]
    public void AddControl(Control value)
    {
        Console.WriteLine($"User add control: {value.Name}");
    }
}