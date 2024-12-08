﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace KoiShowManagement.Repositories.Models;

public partial class Feedback
{
    public int FeedbackId { get; set; }

    public int? CompetitionId { get; set; }

    public int? UserId { get; set; }

    public int? Rating { get; set; }

    public string Comments { get; set; }

    public DateTime? FeedbackDate { get; set; }

    public bool? IsDeleted { get; set; }

    public string Response { get; set; }

    public DateTime? ResponseDate { get; set; }

    public string FeedbackType { get; set; }

    public int? Status { get; set; }

    public bool? IsAnonymous { get; set; }

    public string VisibilityLevel { get; set; }

    public string SeverityLevel { get; set; }

    public bool? IsResponded { get; set; }

    public string Platform { get; set; }

    public virtual Competition Competition { get; set; }

    public virtual User User { get; set; }
}