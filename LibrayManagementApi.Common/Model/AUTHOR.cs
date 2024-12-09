using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrayManagementApi.Common.Model
{
    public class AUTHOR
    {
        [Key]
        public int ID { get; set; }
        public string NAME { get; set; }
        public int AGE { get; set; }
    }
}
