using PMApp.API.Models.Schemas.Bases;

namespace PMApp.API.Models.Schemas
{
    public class ProjectFilter : BaseFilter
    {
        public ProjectFilter() {
            Limit = 1;
        }
        /// <summary>
        /// Criteria for sorting
        /// </summary>
        public string? SortBy {get; set;}
        /// <summary>
        /// Sorting method
        /// </summary>
        public string? OrderBy {get; set;}
    }
}