namespace API.Data
{
    /// <summary>
    /// Response format 1 nesting level of https://api.postcodes.io/postcodes/{postcode}
    /// </summary>
    public class PostcodeData
    {
        public int Status { get; set; }
        public Result Result { get; set; }

    }
}
