// <copyright file="Person.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// </copyright>

namespace TestWebApp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class Person
    {
        [HiddenInput(DisplayValue =false)]
        public int Personld { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name="Date of Birth")]
        public DateTime BirthDate { get; set; }

        public Address HomeAddress { get; set; }

        public bool IsApproved { get; set; }

        public Role Role { get; set; }
    }
}