using System;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using CommunityToolkit.Mvvm.Input;

namespace ReporterUI.ViewModels;

public class Group
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private string _greeting = "Welcome to Avalonia!";



    private ObservableCollection<Group> _groups;

    public ObservableCollection<Group> Groups
    {
        get => _groups;
        set => SetProperty(ref _groups, value);
    }

    public MainViewModel()
    {
        _groups = new ();
        for (int i = 0; i <100; i++)
        {
            _groups.Add(
                new Group
                {
                    ID = i,
                    Name = $"Group {i} Long name for group {i + 1} Group_{i}_Long_name_for_group {i + 1}" ,
                    Description = $"Group number {i} is a group number {i}\nGroup number {i} is a group number {i}",
                }
            );
        }
    }

    [RelayCommand]

    private void GroupSortUp()
    {
        Console.WriteLine("Sort up.");
        OnPropertyChanged(nameof(Groups));
    }
    
    [RelayCommand]
    private void GroupSortDown()
    {
        _groups = new ObservableCollection<Group>(_groups.Reverse());
        Console.WriteLine("Sort down.");
        OnPropertyChanged(nameof(Groups));
    }
}