using Newtonsoft.Json;
using System.Collections.Generic;

namespace TicketGuardian.Net.Models
{
    public class PagedListModel<T> where T : new()
    {
        [JsonProperty("count")]
        public int TotalCount { get; set; }

        [JsonIgnore]
        public int PageSize { get; set; }

        [JsonIgnore]
        public int TotalPages
        {
            get
            {
                var totalPages = 0;

                if (TotalCount > 0)
                {
                    totalPages = TotalCount / PageSize;

                    if (totalPages % PageSize > 0)
                    {
                        totalPages++;
                    }
                }

                return totalPages;
            }
        }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("previous")]
        public string Previous { get; set; }

        [JsonProperty("results")]
        public List<T> Results { get; set; }

        public PagedListModel()
        {
            Results = new List<T>();
        }
    }
}