using Kanbanize.KanbanizeRestClient;
using Kanbanize.DTOs.Task;
using System;
using RestSharp;
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
            _client = new Rest();
            _apiKey = _client.GetApiKey();
        }
    }
}
