using MySomething.CustomValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySomething.Models
{
    public class UserViewModel
    {
        public UserViewModel()
        {
            List<SelectListItem> typeList = new List<SelectListItem>();
            SelectListItem typeListItem = new SelectListItem();
            typeListItem.Text = "Admin";
            typeListItem.Value = "0";
            typeList.Add(typeListItem);

            SelectListItem typeListItem2 = new SelectListItem();
            typeListItem2.Text = "Normal";
            typeListItem2.Selected = true;
            typeListItem2.Value = "1";
            typeList.Add(typeListItem2);

            this.TypeList = typeList;
            this.CreateDate = DateTime.Now;
        }
        public int Id { get; set; }

        [Required]
        [MahmutOlmaz]
        public string Name { get; set; }

        [Required]
        [MahmutOlmaz]
        public string Surname { get; set; }

        [Required]
        [MinLength(5)]
        public string Username { get; set; }

        [Required]
        [MinLength(5)]
        [DataType(DataType.Password)]
        [myPassword]
        public string Password { get; set; }

        [Range(0,1)]
        public int Type { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime CreateDate { get; set; }
        public string FullName
        {
            get
            {
                return this.Name + " " + this.Surname;
            }
        }

        public List<SelectListItem> TypeList
        {
            get;set;
        }
    }
}