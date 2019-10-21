using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StaffList.Models {
    public class CreateViewModel {

        public Employees Emp { get; set; }

        [Display(Name="Отдел")]
        public IEnumerable<Department> Departments { get; set; }

        [Display(Name = "Должность")]
        public IEnumerable<Position> Positions { get; set; }

    }
}