﻿using System.ComponentModel.DataAnnotations;

namespace UdemyDateApi.Dtos
{
    public class UserDto
    {
        
        public required string UserName { get; set; }
   
        public required string Token { get; set; }
    }
}