﻿using System.ComponentModel.DataAnnotations;

namespace Diploma.WebUI.Models.FormModels
{
    public class LoginFormModel
    {
        [Required(ErrorMessage = "'Email' Xanasını boş saxlamayın!")]
        [EmailAddress]
        
        public string Email { get; set; }
        [Required(ErrorMessage = "'Şifrə' Xanasını boş saxlamayın!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
