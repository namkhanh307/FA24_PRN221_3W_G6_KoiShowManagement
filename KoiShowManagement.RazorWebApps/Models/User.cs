﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace KoiShowManagement.RazorWebApps.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string Email { get; set; }

    public string FullName { get; set; }

    public string PhoneNumber { get; set; }

    public string Address { get; set; }

    public int? Status { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string ProfileImage { get; set; }

    public DateTime? CreationDate { get; set; }

    public int? RoleId { get; set; }

    public bool? IsDeleted { get; set; }

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();

    public virtual ICollection<PointOnProgressing> PointOnProgressings { get; set; } = new List<PointOnProgressing>();

    public virtual ICollection<Registration> Registrations { get; set; } = new List<Registration>();

    public virtual Role Role { get; set; }
}