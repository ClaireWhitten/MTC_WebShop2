using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MTCmodel
{
    public class TestModel
    {
        [Key]
        public int Id { get; set; }


        [Required]
        public string  Name { get; set; }

    }
}
