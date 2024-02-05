namespace PMApp.API.Models.Schemas.Bases
{
    public class BaseFilter
    {
        /// <summary>
        /// Search keyword
        /// </summary>
        public string? SearchString {set; get;}
        /// <summary>
        /// Maximum number of records to return
        /// </summary>
        public int Limit {get; set;}
        /// <summary>
        /// Number of records to skip for pagination
        /// </summary>
        public int Offset {get; set;}
    }
}