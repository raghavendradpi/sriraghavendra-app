using System;

namespace API.Entities
{
    public static class CommonItem
    {
        //Contact sheet Information

        public static readonly string ContactSheet = "contact-info";
        public static readonly string Contactrange = $"{ContactSheet}!" + "A:I";


        public static readonly string LatestUpdateSheet = "latest-update";
        // private static readonly char LatestUpdateColumn = 'F';
        public static readonly string LatestUpdaterange = $"{LatestUpdateSheet}!" + "A:F";

        public static readonly string SevaUpdateSheet = "seva-list";
        // private static readonly char SevaUpdateColumn = 'B';
        public static readonly string SevaUpdaterange = $"{SevaUpdateSheet}!" + "A:C";
        ///Aradhana Sheet Dynamic Information with different spreadsheet.
        //public static readonly string AradhanaSheetPartial = "aradhana-";
        //public static string Year = DateTime.Now.Year.ToString();
        public static readonly string AradhanaSheet = "aradhana-collection";
        public static readonly string Aradhanarange = $"{AradhanaSheet}!" + "A:N";

        public static readonly string UserClarificationSheet = "clarification-list";
        public static readonly string UserClarificationrange = $"{UserClarificationSheet}!" + "A:F";

        public enum EmailFlow
        {
            AradhanaAmountReceived,
            Donation,
            Clarification
        }
        public static string GenerateUniqueId()
        {
            var Id = Guid.NewGuid().ToString();
            Id = Id.Replace("/", "aa");
            Id = Id.Replace("-", "bb");
            return Id;
        }
    }
}