﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace KoiShowManagement.RazorWebApps.Models;

public partial class FinalResult
{
    public int CompetitionResultId { get; set; }

    public int? CompetitionId { get; set; }

    public string ResultName { get; set; }

    public string ResultDescription { get; set; }

    public double? TotalScore { get; set; }

    public int? Rank { get; set; }

    public string Comments { get; set; }

    public bool? IsFinalized { get; set; }

    public bool? IsPublished { get; set; }

    public string Category { get; set; }

    public bool? Status { get; set; }

    public int? PrizeAmount { get; set; }

    public string PrizeDescription { get; set; }

    public bool? IsDeleted { get; set; }

    public int? CategoryId { get; set; }

    public virtual CompetitionCategory CategoryNavigation { get; set; }

    public virtual Competition Competition { get; set; }
}