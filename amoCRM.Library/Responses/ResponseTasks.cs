using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using amoCRM.Library.Core.Objects;
using Newtonsoft.Json;

namespace amoCRM.Library.Responses
{
    public class ResponseTasks : ApiResponse<TaskList>
    {
    }

    public class TaskList : ApiResult
    {
        [JsonProperty(PropertyName = "tasks")]
        public ReadOnlyCollection<Task> Tasks { get; set; }
    }
}
