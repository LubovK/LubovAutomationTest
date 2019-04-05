namespace API.Data
{
    /// <summary>
    /// Response format 2 nesting level of https://api.postcodes.io/postcodes/{postcode}
    /// Response -> Result
    /// </summary>
    public class Result
    {
        public string postcode { get; set; }
        public string quality { get; set; }
        public string eastings { get; set; }
        public string northings { get; set; }
        public string country { get; set; }
        public string nhs_ha { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string european_electoral_region { get; set; }
        public string primary_care_trust { get; set; }
        public string region { get; set; }
        public string lsoa { get; set; }
        public string msoa { get; set; }
        public string incode { get; set; }
        public string outcode { get; set; }
        public string parliamentary_constituency { get; set; }
        public string admin_district { get; set; }
        public string parish { get; set; }
        public string admin_county { get; set; }
        public string admin_ward { get; set; }
        public string ced { get; set; }
        public string ccg { get; set; }
        public string nuts { get; set; }
        public Codes Codes { get; set; }
    }
}
