using System;
using System.Linq;
using RestSharp;
using Kanbanize.Helpers;
using Kanbanize.DTOs.Users;
using Kanbanize.Builders.UserBuilder;
using Kanbanize.DTOs.Task;

namespace Kanbanize.KanbanizeRestClient
{
    public class Rest
    {
        public string GetApiKey()
        {
            var client = new RestClient(Helper.BaseUrl + Helper.Login);
            var request = new RestRequest();
            request.Method = Method.Post;
            var currentUser = CreateUser();
            request.AddJsonBody(currentUser);
            var response = client.Execute(request);
            var apiKey = response.Content.Split(new string[] { "\":\"" }, StringSplitOptions.None).Last().Split('\"').First();
            return apiKey;
        }

        public RestResponse PostNewTask(string apiKey)
        {
            var client = new RestClient(Helper.BaseUrl + Helper.CreateTask);
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("apiKey", apiKey);
            var currentTask = CreateTask();
            request.AddJsonBody(currentTask);
            var response = client.Execute(request);
            return response;
        }

        public RestResponse DeleteTask(string apiKey)
        {
            var client = new RestClient(Helper.BaseUrl + Helper.DeleteTask);
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("apiKey", apiKey);
            var currentTask = CreateTask();
            request.AddJsonBody(currentTask);
            var response = client.Execute(request);
            return response;
        }

        public RestResponse MoveTask(string apiKey)
        {
            var client = new RestClient(Helper.BaseUrl + Helper.MoveTask);
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("apiKey", apiKey);
            var currentTask = MoveCreateTask();
            request.AddJsonBody(currentTask);
            var newColumn = new KanbanizeTask {column = "In Progress"};
            request.AddJsonBody(newColumn);
            var response = client.Execute(request);
            return response;
        }

        public KanbanizeTask MoveCreateTask()
        {
            var builder = new TaskBuilder();
            var user = builder.MoveDefaultTask().MoveBuild();
            return user;
        }

        public KanbanizeTask CreateTask()
        {
            var builder = new TaskBuilder();
            var user = builder.DefaultTask().Build();
            return user;
        }

        public User CreateUser()
        {
            var builder = new UserBuilder();
            var user = builder.DefaultUser().Build();
            return user;
        }

        public static implicit operator Rest(KanbanizeTask v)
        {
            throw new NotImplementedException();
        }
    }
}
