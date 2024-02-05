namespace PMApp.API.Models.Schemas.Bases
{
    public class BaseListOfData<TData>
    {
        public BaseListOfData()
        {
            Datas = new List<TData>();
            Paging = new Paging();
        }
        /// <summary>
        /// List of records
        /// </summary>
        /// <value></value>
        public List<TData> Datas {set; get;}
        /// <summary>
        /// Paging information
        /// </summary>
        /// <value></value>
        public Paging Paging {get; set;}
    }
}