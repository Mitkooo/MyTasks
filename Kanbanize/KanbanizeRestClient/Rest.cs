using Kanbanize.Builders;
using Kanbanize.DTOs;
using RestSharp;
using System;
using System.Linq;
using Kanbanize.Helpers;
using Kanbanize.DTOs.Task;
using Kanbanize.Builders.UserBuilder;
using Kanbanize.DTOs.Users;

namespace Kanbanize.KanbanizeRestClient
{
    public class Rest
    {

        public string GetApiKey()
        {
            RestClient client = new RestClient(Helper.BaseUrl + Helper.Login);
            RestRequest request = new RestRequest();
            request.Method = Method.Post;
            var currentUser = CreateUser();
            request.AddBody(currentUser);
            RestResponse response = client.Execute(request);
            var apiKey = response.Content.Split(new string[] { "\":\"" }, StringSplitOptions.None).Last().Split('\"').First();
            Console.WriteLine(apiKey);
            return apiKey;
        }

        public RestResponse PostNewTask(string apiKey, object currentTask)
        {
            var client = new RestClient(Helper.BaseUrl + Helper.CreateTask);
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("apiKey", apiKey);
            request.AddJsonBody(currentTask);
            var response = client.Execute(request);
            return response;
        }

        public RestResponse DeleteTask(string apiKey, object currentTask)
        {
            var client = new RestClient(Helper.BaseUrl + Helper.DeleteTask);
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("apiKey", apiKey);
            request.AddJsonBody(currentTask);
            var response = client.Execute(request);
            return response;
        }

        public RestResponse MoveTask(string apiKey, object currentTask)
        {
            var client = new RestClient(Helper.BaseUrl + Helper.MoveTask);
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("apiKey", apiKey);
            request.AddJsonBody(currentTask);
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
    }
}
