using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StaffList.Models {
    public class CreateViewModel {

        public Employees Emp { get; set; }

        public List<Department> Departments { get; set; }

        public Position PosUser { get; set; }

    }
}