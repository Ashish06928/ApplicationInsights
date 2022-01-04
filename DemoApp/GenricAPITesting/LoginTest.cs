using GenricAPI;
using Microsoft.Extensions.Primitives;
using Serilog;
using System;
using System.Collections.Generic;
using Xunit;

namespace GenricAPITesting
{
    public class LoginTest
    {

        [Fact]
        public void Login()
        {
            var query = new Dictionary<String, StringValues>();
            query.TryAdd(“name”, “ushio”);
            var body = “”;
            User.Login(req: HttpRequestSetup(query, body), log: Log)
        }
    }
}
