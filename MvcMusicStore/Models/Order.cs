using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Models
{
    [Bind(Exclude = "OrderId")]
    public  partial class Order
    {

        [ScaffoldColumn(false)]
        public int OrderId { get; set; }
        [ScaffoldColumn(false)]
        public System.DateTime OrderDate { get; set; }
        [ScaffoldColumn(false)]
        public string Username { get; set; }
        [Required(ErrorMessage = "First Name is required")]








        [DisplayName("名字")]
        [StringLength(160)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]






        [DisplayName("姓")]
        [StringLength(160)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Address is required")]




        [DisplayName("地址")]
        [StringLength(70)]
        public string Address { get; set; }
        [Required(ErrorMessage = "City is required")]







        [DisplayName("城市")]
        [StringLength(40)]
        public string City { get; set; }
        [Required(ErrorMessage = "State is required")]




        [DisplayName("州")]
        [StringLength(40)]
        public string State { get; set; }
        [Required(ErrorMessage = "Postal Code is required")]









        [DisplayName("邮政编码")]
        
        [StringLength(10)]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Country is required")]










        [DisplayName("国家")]
        [StringLength(40)]
        public string Country { get; set; }
        [Required(ErrorMessage = "Phone is required")]









        [DisplayName("手机号码")]
        [StringLength(24)]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Email Address is required")]       
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}",
        ErrorMessage = "Email is is not valid.")]
        [DataType(DataType.EmailAddress)]







        [DisplayName("电子邮箱")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [ScaffoldColumn(false)]
        public decimal Total { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}


