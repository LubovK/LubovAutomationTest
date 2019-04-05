namespace API.Data
{
    /// <summary>
    /// Response format of https://api.postcodes.io/postcodes/{postcode}/validate
    /// </summary>
    public class PostcoseValidationData
    {
        public int Status { get; set; }
        public bool Result { get; set; }
    }
}
