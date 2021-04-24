using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Parcial2_GabrielZeballosp.Models
{
    public class friend
    {
        [Key]
        public int FriendID { get; set; }
        [Required]
        [StringLength(30,ErrorMessage ="El nombre debe ser entre 3 y 30 caracteres",MinimumLength =3)]
        public string Name { get; set; }
        public string NickName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}",ApplyFormatInEditMode =true)]
        public DateTime Birthday { get; set; }
    }
}