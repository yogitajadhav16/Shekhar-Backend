using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo.Models
{
    public class User
    {
        public string userId { get; set; }
		
        public string firstName { get; set; }

        public string lastName { get; set; }

        public string address { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public string email { get; set; }

        public string gender { get; set; }
    }
}