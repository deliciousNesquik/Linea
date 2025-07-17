using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Linea.Core.Services;
using Linea.UI.UserControls;
using Attribute = Linea.Core.Models.Attribute;

namespace Linea.UI.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    // [ObservableProperty] private Control _control;
    // [ObservableProperty] private Core.Models.Control _controlCore;
    // [ObservableProperty] private List<Core.Models.Control> _allControls;
    // [ObservableProperty] private Core.Models.Control _selectedControl;
    // [ObservableProperty] private List<Core.Models.Attribute> _attributesSelectedControl;
    // [ObservableProperty] private Core.Models.Attribute _selectedAttribute;
    // [ObservableProperty] private string _markupCode;

    [ObservableProperty] private UserControl _leftPanelUserControl;
    [ObservableProperty] private UserControl _rightPanelUserControl;
    [ObservableProperty] private UserControl _topPanelUserControl;
    [ObservableProperty] private UserControl _bottomPanelUserControl;
    
    [ObservableProperty] private ToolBoxViewModel _toolBoxViewModel;

    public MainWindowViewModel()
    {
        ToolBoxViewModel = new ToolBoxViewModel();

        LeftPanelUserControl = new ToolBoxUserControl { DataContext = ToolBoxViewModel };
        RightPanelUserControl = new UserControl();
        TopPanelUserControl = new UserControl();
        BottomPanelUserControl = new UserControl();
    }
    
    /*partial void OnSelectedAttributeChanged(Attribute value)
    {
        foreach (var attribute in ControlCore.Attributes)
        {
            if (attribute.Name == value.Name)
                attribute.Value = value.Value;
        }
        
        var xaml = new MarkupGenerator(new MarkupBuilder(), new MarkupFormatter(), new MarkupRules()).Generate(ControlCore);
        var target = AvaloniaRuntimeXamlLoader.Parse<Control>(xaml);

        MarkupCode = xaml;
        Control = target;
        AttributesSelectedControl = ControlCore.Attributes;
    }

    partial void OnMarkupCodeChanged(string value)
    {
        try
        {
            Control = AvaloniaRuntimeXamlLoader.Parse<Control>(value);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    partial void OnSelectedControlChanged(Core.Models.Control value)
    {
        ControlCore = value.Clone();
        ControlCore.Attributes.Add(new Attribute());
        ControlCore.Attributes[^1].Name = "xmlns";
        ControlCore.Attributes[^1].Value = "https://github.com/avaloniaui";
        
        var xaml = new MarkupGenerator(new MarkupBuilder(), new MarkupFormatter(), new MarkupRules()).Generate(ControlCore);
        var target = AvaloniaRuntimeXamlLoader.Parse<Control>(xaml);

        MarkupCode = xaml;
        Control = target;
        AttributesSelectedControl = ControlCore.Attributes;
    }*/
}