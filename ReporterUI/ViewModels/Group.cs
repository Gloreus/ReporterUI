using System;

namespace ReporterUI.ViewModels;

public class Group : IComparable<Group>
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }

    public int CompareTo(Group? other)
    {
        if (other == null) return -1;
        return string.Compare(Name, other.Name, StringComparison.CurrentCulture);
    }

    public override string ToString()
    {
        return Name;
    }

    public override bool Equals(object? obj)
    {
        if (obj is Group g)
        {
            return this.Name.Equals(g.Name);
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }
}

public class Report : IComparable<Report>
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public bool Enabled { get; set; }
    public required Group Group { get; set; }

    public int CompareTo(Report? other)
    {
        if (other == null) return -1;
        return string.Compare(Name, other.Name, StringComparison.CurrentCulture);
    }

    public override string ToString()
    {
        return Name;
    }
}