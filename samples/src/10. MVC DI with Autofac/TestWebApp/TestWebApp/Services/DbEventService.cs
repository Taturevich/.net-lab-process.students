// <copyright file="DbEventService.cs" company="EPAM Systems">
// Copyright (c) EPAM Systems. All rights reserved.
// </copyright>

namespace TestWebApp.Services
{
    using System;

    public class DbEventService : IEventService
    {
        public string GetEventById(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            return $"This is event with ID = {id}";
        }
    }
}