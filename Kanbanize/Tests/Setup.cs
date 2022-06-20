using Kanbanize.Builders.UserBuilder;
using Kanbanize.KanbanizeRestClient;
using System;
using RestSharp;
using Kanbanize.DTOs.Task;
using NUnit.Framework;

namespace Kanbanize.Tests
{
    public class Setup
    {
        public Rest _client;
        public KanbanizeTask _task = new KanbanizeTask();
        public RestResponse _response;
        public string _apiKey;

        [SetUp]
        public void Base()
        {
            _client = new KanbanizeTask();
            _apiKey = _client.GetApiKey();
        }
    }
}
