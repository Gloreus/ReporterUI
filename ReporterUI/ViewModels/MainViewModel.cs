using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Styling;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using FluentAvalonia.Styling;

namespace ReporterUI.ViewModels;

public enum SortOrder
{
    None = 0,
    Ascending,
    Descending
}

public partial class MainViewModel : ViewModelBase
{
    private const int TestItemsCount = 1000;

    [ObservableProperty] private string _log = string.Empty;


    private Group? _currentGroup = null;

    public Group? CurrentGroup
    {
        get => _currentGroup;
        set
        {
            SetProperty(ref _currentGroup, value);
            Log += "\n" + value?.Name;
        }
    }

    [ObservableProperty] private string _greeting = "Welcome to Avalonia!";

    private readonly List<Group> _items = new(100);

    [ObservableProperty] private IEnumerable<Group> _itemsSource;

    private SortOrder _sortOrder = SortOrder.None;

    public SortOrder SortOrder
    {
        get => _sortOrder;
        set
        {
            if (_sortOrder == value) return;
            _sortOrder = value;
            switch (value)
            {
                case SortOrder.Ascending:
                    _items.Sort((a, b) => a.CompareTo(b));
                    break;
                case SortOrder.Descending:
                    _items.Sort((a, b) => -a.CompareTo(b));
                    break;
                case SortOrder.None: break;
            }

            OnPropertyChanged();
        }
    }

    public MainViewModel()
    {
        for (int i = 0; i < TestItemsCount; i++)
        {
            _items.Add(
                new Group
                {
                    Id = i,
                    Name = $"Group {i} Long name for group {i + 1} Group_{i}_Long_name_for_group {i + 1}",
                    Description = $"Group number {i} is a group number {i} Group number {i} is a group number {i}",
                }
            );
        }

        _itemsSource =
            _items.OrderBy(group => group.Name);
    }

    [RelayCommand]
    private void GroupSortUp()
    {
        SortOrder = SortOrder.Ascending;
        ItemsSource =
            _items.OrderBy(g => g.Name);
        Console.WriteLine("Sort Up.");
    }

    [RelayCommand]
    private void GroupSortDown()
    {
        SortOrder = SortOrder.Descending;
        ItemsSource =
            _items.OrderByDescending(g => g.Name);
        Console.WriteLine("Sort down.");
    }

    [RelayCommand]
    private void ThemeChange()
    {
        if (Application.Current.ActualThemeVariant == ThemeVariant.Light)
        {
            Application.Current.RequestedThemeVariant = ThemeVariant.Dark;
        }
        else
        {
            Application.Current.RequestedThemeVariant = ThemeVariant.Light;
        }
    }

    public void ChangeGroup()
    {
        Log += CurrentGroup?.Name;
    }
}