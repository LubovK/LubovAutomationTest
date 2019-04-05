namespace API.Data
{
    /// <summary>
    /// Response format 3 nesting level of https://api.postcodes.io/postcodes/{postcode}
    /// Response -> Result -> Codes
    /// </summary>
    public class Codes
    {
        public string admin_district { get; set; }
        public string admin_county { get; set; }
        public string admin_ward { get; set; }
        public string parish { get; set; }
        public string parliamentary_constituency { get; set; }
        public string ccg { get; set; }
        public string ced { get; set; }
        public string nuts { get; set; }
    }
}
