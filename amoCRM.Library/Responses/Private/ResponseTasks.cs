using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using amoCRM.Library.Core.Objects.Private;
using Newtonsoft.Json;

namespace amoCRM.Library.Responses.Private
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
