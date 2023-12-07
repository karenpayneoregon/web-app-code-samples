using TheftReportingApp.Models;

namespace TheftReportingApp.Classes;

public static class StateArray
{

    static List<US_State> states;

    static StateArray()
    {
        states = new(50)
        {
            new("AL", "Alabama"),
            new ("AK", "Alaska"),
            new ("AZ", "Arizona"),
            new ("AR", "Arkansas"),
            new ("CA", "California"),
            new ("CO", "Colorado"),
            new ("CT", "Connecticut"),
            new ("DE", "Delaware"),
            new ("FL", "Florida"),
            new ("GA", "Georgia"),
            new ("HI", "Hawaii"),
            new ("ID", "Idaho"),
            new ("IL", "Illinois"),
            new ("IN", "Indiana"),
            new ("IA", "Iowa"),
            new ("KS", "Kansas"),
            new ("KY", "Kentucky"),
            new ("LA", "Louisiana"),
            new ("ME", "Maine"),
            new ("MD", "Maryland"),
            new ("MA", "Massachusetts"),
            new ("MI", "Michigan"),
            new ("MN", "Minnesota"),
            new ("MS", "Mississippi"),
            new ("MO", "Missouri"),
            new ("MT", "Montana"),
            new ("NE", "Nebraska"),
            new ("NV", "Nevada"),
            new ("NH", "New Hampshire"),
            new ("NJ", "New Jersey"),
            new ("NM", "New Mexico"),
            new ("NY", "New York"),
            new ("NC", "North Carolina"),
            new ("ND", "North Dakota"),
            new ("OH", "Ohio"),
            new ("OK", "Oklahoma"),
            new ("OR", "Oregon"),
            new ("PA", "Pennsylvania"),
            new ("RI", "Rhode Island"),
            new ("SC", "South Carolina"),
            new ("SD", "South Dakota"),
            new ("TN", "Tennessee"),
            new ("TX", "Texas"),
            new ("UT", "Utah"),
            new ("VT", "Vermont"),
            new ("VA", "Virginia"),
            new ("WA", "Washington"),
            new ("WV", "West Virginia"),
            new ("WI", "Wisconsin"),
            new ("WY", "Wyoming")
        };
    }

    public static string[] Abbreviations()
    {
        List<string> abbrevList = new(states.Count);

        foreach (var state in states)
        {
            abbrevList.Add(state.Abbreviation);
        }

        return abbrevList.ToArray();
    }

    public static string[] Names()
    {
        List<string> nameList = new(states.Count);
        foreach (var state in states)
        {
            nameList.Add(state.Name);
        }

        return nameList.ToArray();
    }

    public static List<US_State> States(bool addSelect = false)
    {
        if (addSelect)
        {
            states.Insert(0, new US_State("None", "---Select---"));
        }
        
        return states.ToList();
    }

}