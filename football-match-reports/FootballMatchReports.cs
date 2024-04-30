using System;

public static class PlayAnalyzer {
    public static string AnalyzeOnField(int shirtNum) {
        switch (shirtNum) {
            case 1:
                return "goalie";
            case 2:
                return "left back";
            case 3:
            case 4:
                return "center back";
            case 5:
                return "right back";
            case 6:
            case 7:
            case 8:
                return "midfielder";
            case 9:
                return "left wing";
            case 10:
                return "striker";
            case 11:
                return "right wing";
            default:
                throw new ArgumentOutOfRangeException(nameof(shirtNum));
        }
    }

    public static string AnalyzeOffField(object report) {
        switch (report) {
            case int count:
                return $"There are {count} supporters at the match.";
            case string message:
                return message;
            case Injury injury:
                return $"Oh no! {injury.GetDescription()} Medics are on the field.";
            case Incident incident:
                return incident.GetDescription();
            case Manager manager:
                return manager.Club == null ? manager.Name : $"{manager.Name} ({manager.Club})";
            default:
                throw new ArgumentException("Invalid input type");
        }
    }
}
