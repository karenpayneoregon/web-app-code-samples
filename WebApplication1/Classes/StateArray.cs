using WebApplication1.Models;

namespace WebApplication1.Classes;

public static class StateArray
{

    static List<US_State> states;

    static StateArray()
    {
        states = new(50)
        {
            new(1, "AL", "Alabama"),
            new (2, "AK", "Alaska"),
            new (3, "AZ", "Arizona"),
            new (4, "AR", "Arkansas"),
            new (5, "CA", "California"),
            new (6, "CO", "Colorado"),
            new (7, "CT", "Connecticut"),
            new (8, "DE", "Delaware"),
            new (9, "FL", "Florida"),
            new (10, "GA", "Georgia"),
            new (11, "HI", "Hawaii"),
            new (12, "ID", "Idaho"),
            new (13, "IL", "Illinois"),
            new (14, "IN", "Indiana"),
            new (15, "IA", "Iowa"),
            new (16, "KS", "Kansas"),
            new (17, "KY", "Kentucky"),
            new (18, "LA", "Louisiana"),
            new (19, "ME", "Maine"),
            new (20, "MD", "Maryland"),
            new (21, "MA", "Massachusetts"),
            new (22, "MI", "Michigan"),
            new (23, "MN", "Minnesota"),
            new (24, "MS", "Mississippi"),
            new (25, "MO", "Missouri"),
            new (26, "MT", "Montana"),
            new (27, "NE", "Nebraska"),
            new (28, "NV", "Nevada"),
            new (29, "NH", "New Hampshire"),
            new (30, "NJ", "New Jersey"),
            new (31, "NM", "New Mexico"),
            new (32, "NY", "New York"),
            new (33, "NC", "North Carolina"),
            new (34, "ND", "North Dakota"),
            new (35, "OH", "Ohio"),
            new (36, "OK", "Oklahoma"),
            new (37, "OR", "Oregon"),
            new (38, "PA", "Pennsylvania"),
            new (39, "RI", "Rhode Island"),
            new (40, "SC", "South Carolina"),
            new (41, "SD", "South Dakota"),
            new (42, "TN", "Tennessee"),
            new (43, "TX", "Texas"),
            new (44, "UT", "Utah"),
            new (45, "VT", "Vermont"),
            new (46, "VA", "Virginia"),
            new (47, "WA", "Washington"),
            new (48, "WV", "West Virginia"),
            new (49, "WI", "Wisconsin"),
            new (50, "WY", "Wyoming")
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
            states.Insert(0, new US_State("None", ""));
        }
        
        return states.ToList();
    }

}