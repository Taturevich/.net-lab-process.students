// <copyright file="Appointment.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// </copyright>

namespace TestWebApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Appointment
    {
        [Required]
        [StringLength(10, MinimumLength = 3)]
        public string ClientName { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter date")]
        public DateTime Date { get; set; }

        public bool TermsAccepted { get; set; }
    }
}