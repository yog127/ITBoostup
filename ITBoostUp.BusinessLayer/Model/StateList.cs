﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITBoostUp.BusinessLayer.Model
{
    public class StateList : AuditEntity
    {
        public int StateId { get; set; }
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string StateDescription { get; set; }
    }
}
