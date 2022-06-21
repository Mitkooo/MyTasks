using Kanbanize.DTOs.Task;

namespace Kanbanize.Builders.UserBuilder
{
    public class TaskBuilder
    {
        private KanbanizeTask _task;

        public TaskBuilder()
        {
            _task = new KanbanizeTask();
        }

        public TaskBuilder MoveDefaultTask()
        {
            _task = new KanbanizeTask();
            _task.boardid = "1";
            _task.column = "In Progress";
            _task.priority = "High";
            _task.assignee = "Dimitar";
            _task.title = "New Test task";
            _task.deadline = "2026-6-5";
            _task.description = "This is a new test task create by me!";
            return this;
        }

        public TaskBuilder DefaultTask()
        {
            _task = new KanbanizeTask();
            _task.boardid = "1";
            _task.column = "Requested";
            _task.priority = "High";
            _task.assignee = "Dimitar";
            _task.title = "New Test task";
            _task.deadline = "2026-6-5";
            _task.description = "This is a new test task.";
            return this;
        }

        public KanbanizeTask MoveBuild()
        {
            return _task;
        }

        public KanbanizeTask Build()
        {
            return _task;
        }
    }
}
