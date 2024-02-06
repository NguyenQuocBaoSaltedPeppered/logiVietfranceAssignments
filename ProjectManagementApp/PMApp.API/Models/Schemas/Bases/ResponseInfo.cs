namespace PMApp.API.Models.Schemas.Bases
{
    public class ResponseInfo
    {
        public ResponseInfo()
        {
            Message = "";
            StatusCode = 200;
            ResponseData = new Dictionary<string, string>();
        }
        /// <summary>
        /// Message for the response
        /// </summary>
        public string? Message {set; get;}
        /// <summary>
        /// Status Code for the response
        /// </summary>
        public int StatusCode {get; set;}
        /// <summary>
        /// Dictionary for the neccessary responseData
        /// </summary>
        public Dictionary<string, string> ResponseData {get; set;}
    }
}