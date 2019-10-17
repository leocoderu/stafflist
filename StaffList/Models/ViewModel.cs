using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaffList.Models {
    public class ViewModel {

        public Employees Emp { get; set; }
        public Department DepUser { get; set; }
        public Position PosUser { get; set; }

    }
}