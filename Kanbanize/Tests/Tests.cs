using System;
using NUnit.Framework;
using Kanbanize.KanbanizeRestClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kanbanize.Tests
{
    [TestClass]
    public class Tests : Setup
    {
        [TestMethod]
        public void ApiKeyIsReturned()
        {
            Base();
            NUnit.Framework.Assert.IsTrue(_apiKey != null);
        }

        [TestMethod]
        public void VerifyTaskhasBeenCreated()
        {
            _client = new Rest();
            _task = _client.CreateTask();
            _response = _client.PostNewTask(_apiKey, _task);
            NUnit.Framework.Assert.That(_task.assignee == "Dimitar");
            NUnit.Framework.Assert.IsTrue(_response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        [TestMethod]

        public void VerifyTaskHasBeenCreatedWithCorrectParameters()
        {
            _client = new Rest();
            _task = _client.CreateTask();
            _response = _client.PostNewTask(_apiKey, _task);
            NUnit.Framework.Assert.That(_task.boardid == "1");
            NUnit.Framework.Assert.That(_task.title == "New Test task" && _task.description == "This is a new test task.");
            NUnit.Framework.Assert.That(_task.deadline == "2026-6-5");
        }

        [TestMethod]

        public void VerifyTaskHasBeenCreatedInCorrectColumn()
        {
            _client = new Rest();
            _task = _client.CreateTask();
            _response = _client.PostNewTask(_apiKey, _task);
            NUnit.Framework.Assert.That(_task.column == "Requested");
        }

        [TestMethod]

        public void VerifyTaskHasBeenMoved()
        {
            _client = new Rest();
            _task = _client.MoveCreateTask();
            _response = _client.MoveTask(_apiKey, _task);
            NUnit.Framework.Assert.That(_task.column == "In Progress");
        }

        [TestMethod]

        public void VerifyTaskBasBeenDeleted()
        {
            _client = new Rest();
            _task = _client.CreateTask();
            _response = _client.DeleteTask(_apiKey, _task);
        }
    }
}
