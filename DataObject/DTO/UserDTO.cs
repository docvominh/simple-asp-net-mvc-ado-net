﻿using System;

namespace DataObject.DTO
{
    public class UserDTO
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime LastLogin { get; set; }
        public bool Active { get; set; }
    }
}