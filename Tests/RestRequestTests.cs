using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace TestProject.Tests
{
    [TestFixture]
    class RestRequestTests
    { 
        private RestClient restClient = null;
        [SetUp]
        public void Setup()
        {
             restClient = new RestClient(baseUrl: "https://reqres.in/");
        }

        [Test]
        public void GetMessage()
        {
            RestRequest request = new RestRequest("api/users/{postid}", Method.GET);
            request.AddUrlSegment("postid", 2);
            var response = restClient.Execute(request);
            JObject result = JObject.Parse(response.Content);
            
            var data = result["data"];
            var id = data["id"].ToString();
            var first_name = data["first_name"].ToString();
            var last_name = data["last_name"].ToString();

            Assert.That("OK", Is.EqualTo(response.StatusCode.ToString().Replace("\"","")), $"response is not correct {response.StatusCode}");
            Assert.That("2", Is.EqualTo(id), "Id is not correct");
            Assert.That("Janet", Is.EqualTo(first_name), "First_name is not correct");
            Assert.That("Weaver", Is.EqualTo(last_name), "last_name is not correct");
        }

        [Test]
        public void PutMessage()
        {

            RestRequest request = new RestRequest("api/users/{postid}/profile", Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { name = "Vikram", Job = "Consultant" });
            request.AddUrlSegment("postid", 2);
            var response = restClient.Execute(request);                           
            JObject result = JObject.Parse(response.Content);

            var name = result["name"].ToString();
            var Job = result["Job"].ToString();

            Assert.That("OK", Is.EqualTo(response.StatusCode.ToString().Replace("\"", "")), $"response is not correct {response.StatusCode}");
            Assert.That(name, Is.EqualTo("Vikram"), "Vikram is not correct");
            Assert.That(Job, Is.EqualTo("Consultant"), "Job is not correct");
           
        }

        [Test]
        public void POSTMessage()
        {

            RestRequest request = new RestRequest("api/users/{postid}/profile", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { name = "NewPost", Job = "TestPost" });
            request.AddUrlSegment("postid", 53);
            var response = restClient.Execute(request);
            JObject result = JObject.Parse(response.Content);
            var name = result["name"].ToString();
            var Job = result["Job"].ToString();
            

            Assert.That("Created", Is.EqualTo(response.StatusCode.ToString().Replace("\"", "")), $"response is not correct {response.StatusCode}");
            Assert.That(name, Is.EqualTo("NewPost"), "Vikram is not correct");
            Assert.That(Job, Is.EqualTo("TestPost"), "Job is not correct");
            

        }

        [Test]
        public void DeleteMessage()
        {
            RestRequest request = new RestRequest("api/users/{postid}", Method.DELETE);
            request.AddUrlSegment("postid", 2);
            var response = restClient.Execute(request);
            Assert.That("NoContent", Is.EqualTo(response.StatusCode.ToString().Replace("\"", "")), $"response is not correct {response.StatusCode}");
        }
    }
}
