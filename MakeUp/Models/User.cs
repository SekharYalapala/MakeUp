//namespace MakeupOnline.Models
//{
//    using System;
//    using System.Collections.Generic;
//    using System.ComponentModel.DataAnnotations;

//    public partial class User_table
//    {
//        public int UserId { get; set; }
//        [Required]
//        public string UserName { get; set; }
//        [Required]
//        [DataType(DataType.Password)]
//        public string Password { get; set; }
//        [Required]
//        [Compare("Password", ErrorMessage = "Password is does not match")]
//        public string ConfirmPassword { get; set; }
//        public System.DateTime CreatedDate { get; set; }
//        public Nullable<System.DateTime> LastLoginDate { get; set; }
//    }
//}