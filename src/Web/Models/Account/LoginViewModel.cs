﻿using System.ComponentModel.DataAnnotations;

namespace hshmedstats.Web.Models.Account
{
    public class LoginViewModel
    {
        public LoginViewModel() { }

        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public bool RememberMe { get; set; }
    }
}
