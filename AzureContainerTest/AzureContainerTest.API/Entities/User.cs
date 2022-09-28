using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureContainerTest.API.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public float Age { get; set; }
    }
}
