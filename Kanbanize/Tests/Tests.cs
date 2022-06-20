using System;
using NUnit.Framework;
using Kanbanize.KanbanizeRestClient;

namespace Kanbanize.Tests
{
    public class Tests : Setup
    {
        [Test]
        public void ApiKeyIsReturned()
        {
            Assert.That(_apiKey != null);
        }

        [Test]
        public void VerifyTaskhasBeenCreated()
        {
            _client = new Rest();
            _response = _client.PostNewTask(_apiKey);
            Assert.That(_response.StatusCode == System.Net.HttpStatusCode.OK);
        }

        [Test]
        public void VerifyTaskHasBeenCreatedWithCorrectParameters()
        {
            _client = new Rest();
            _response = _client.PostNewTask(_apiKey);
            Assert.That(_response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.That(_task.boardid == "1");
            Assert.That(_task.title == "New Test task" && _task.description == "This is a new test task create by me!");
            Assert.That(_task.deadline == "2026-6-5");
        }

        [Test]
        public void VerifyTaskHasBeenCreatedInCorrectColumn()
        {
            _client = new Rest();
            _response = _client.PostNewTask(_apiKey);
            Assert.That(_task.column == "Requested");
        }

        [Test]
        public void VerifyTaskHasBeenMoved()
        {
            _client = new Rest();
            _response = _client.MoveTask(_apiKey);
            Assert.That(_task.column == "In Progress");
            Assert.That(_task.taskid == "1");
        }

        [Test]
        public void VerifyTaskBasBeenDeleted()
        {
            _client = new Rest();
            _response = _client.DeleteTask(_apiKey);
            Assert.That(_response.StatusCode == System.Net.HttpStatusCode.OK);
        }
    }
}
