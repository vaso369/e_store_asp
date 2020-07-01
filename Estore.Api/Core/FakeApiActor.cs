using Estore.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estore.Api.Core
{
    public class FakeApiActor : IApplicationActor
    {
        public int Id => 1;

        public string Identity { get => "Test Api User"; }

        public IEnumerable<int> AllowedUseCases => new List<int> { 1,2,3,4,5,6 };
    }
    public class AdminFakeApiActor : IApplicationActor
    {
        public int Id => 2;

        public string Identity { get => "Admin Api Fake"; }

        public IEnumerable<int> AllowedUseCases => Enumerable.Range(1,1000);
    }
}
