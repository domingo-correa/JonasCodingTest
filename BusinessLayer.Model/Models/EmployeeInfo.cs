﻿using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public class EmployeeInfo : BaseDto
    {
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string Occupation { get; set; }
        public string EmployeeStatus { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public DateTime LastModified { get; set; }
    }
}
