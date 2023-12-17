using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace baitap2_CRUD_.Models
{
    public class Student
    {
        [Key]
        public int HocSinhID { get; set; }
        public string HoTen { get; set; }
        public bool GioiTinh { get; set; }
        public int Tuoi { get; set; }
        public DateTime NgaySinh { get; set; }
        public float Luong { get; set; }
    }
}
