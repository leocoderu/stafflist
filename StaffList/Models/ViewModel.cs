using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaffList.Models {
    public class ViewModel {

        public Employees employees { get; set; }
        public Department department { get; set; }
        public Position position { get; set; }

    }
}