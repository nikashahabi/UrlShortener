using System;
using Xunit;
using RA;
namespace tests
{
    public class UnitTest1
    {
        private const string API = "http://localhost:5000";
        [Fact]
        public void Test1()
        {
            new RestAssured()
            .Given()
              .Name("test post endpoint")
              .Header("Content-Type","application/json")
              .Body(new {longUrl = "google.com"})
            .When()
              .Post(API + "/urls")
            .Then()
              .TestStatus("test status", status => status == 200)
              .Assert("test status")
              .TestBody("test body", body => ((string)body.shortUrl).Length == 8 )
              .Assert("test body");
        }
        [Fact]
        public void Test2()
        {
            new RestAssured()
            .Given()
              .Name("test post endpoint")
              .Header("Content-Type","application/json")
              .Body(new {longUrl = "www.google.com"})
            .When()
              .Post(API + "/urls")
            .Then()
              .TestStatus("test status", status => status == 200)
              .Assert("test status");
        }
        [Fact]
        public void Test3(){
            new RestAssured()
            .Given()
              .Name("test post endpoint")
              .Header("Content-Type","application/json")
              .Body(new {longUrl = "http://google.com"})
            .When()
              .Post(API + "/urls")
            .Then()
              .TestStatus("test status", status => status == 200)
              .Assert("test status");
        } 
        [Fact]           
        public void Test4(){
            new RestAssured()
            .Given()
              .Name("test post endpoint")
              .Header("Content-Type","application/json")
              .Body(new {longUrl = "http://www.google.com"})
            .When()
              .Post(API + "/urls")
            .Then()
              .TestStatus("test status", status => status == 200)
              .Assert("test status");
            
        }
        [Fact]
        public void Test5(){
            new RestAssured()
            .Given()
              .Name("test post endpoint")
              .Header("Content-Type","application/json")
              .Body(new {longUrl = "https://google.com"})
            .When()
              .Post(API + "/urls")
            .Then()
              .TestStatus("test status", status => status == 200)
              .Assert("test status");
        }
        [Fact]
        public void Test6(){
            new RestAssured()
            .Given()
              .Name("test post endpoint")
              .Header("Content-Type","application/json")
              .Body(new {longUrl = "https://www.google.com"})
            .When()
              .Post(API + "/urls")
            .Then()
              .TestStatus("test status", status => status == 200)
              .Assert("test status");
        }
        [Fact]
        public void Test7(){
            new RestAssured()
            .Given()
              .Name("test post endpoint")
              .Header("Content-Type","application/json")
              .Body(new {longUrl = "https://www...google.com"})
            .When()
              .Post(API + "/urls")
            .Then()
              .TestStatus("test status", status => status == 400)
              .Assert("test status");
        }
    }
}
