﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace lablinAPI.Models;

public partial class tbl_project_properties
{
    public int id { get; set; }

    public int? projectID { get; set; }

    public int? libraryFacilityID { get; set; }

    public int? sequencingFacilityID { get; set; }

    public int? extractionMethodID { get; set; }

    public int? extractionKitID { get; set; }
}