using System;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.Generic;

namespace ReporterUI.ViewModels;

public class Group
{
    public int ID { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] private string _greeting = "Welcome to Avalonia!";

    public List<Group> Groups { get; }

    public MainViewModel()
    {
        Groups = new List<Group>(100);
        for (int i = 0; i <100; i++)
        {
            Groups.Add(
                new Group
                {
                    ID = i,
                    Name = $"Group {i} Long name for_group_{i + 1}_Group_{i}_Long_name_for_group {i + 1}" ,
                    Description = $"Group number {i} is a group number {i}\nGroup number {i} is a group number {i}",
                }
            );
        }
    }
}