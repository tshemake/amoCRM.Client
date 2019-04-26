using System;
using System.Collections.Generic;
using System.Text;

namespace amoCRM.Library.Helpers
{
    public class QueryParameter
    {
        public ModelType ModelType { get; set; }

        [Parameter("id")]
        public List<int> Ids { get; set; }

        [Parameter("limit_rows")]
        public int? Limit { get; set; }

        [Parameter("limit_offset")]
        public int? Offset { get; set; }

        [Parameter("IF-MODIFIED-SINCE")]
        public DateTime? Since { get; set; }

        [Parameter("query")]
        public string Query { get; set; }

        [Parameter("query")]
        public Dictionary<string, List<int>> Queries { get; set; }

        [Parameter("element_id")]
        public int? ElementId { get; set; }

        [Parameter("type")]
        public ModelType Type { get; set; }
    }
}
