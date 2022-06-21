using System;

namespace Kanbanize.DTOs.Task
{
    public class KanbanizeTask
    {
        public string boardid { get; set; }
        public string taskid { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string priority { get; set; }
        public string assignee { get; set; }
        public string color { get; set; }
        public string tags { get; set; }
        public string deadline { get; set; }
        public string column { get; set; }
    }
}
