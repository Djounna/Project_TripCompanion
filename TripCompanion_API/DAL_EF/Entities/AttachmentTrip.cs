﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace DAL_EF.Entities
{
    public partial class AttachmentTrip
    {
        public int IdAttachment { get; set; }
        public int IdTrip { get; set; }
        public string Label { get; set; }

        public virtual Trip IdTripNavigation { get; set; }
    }
}