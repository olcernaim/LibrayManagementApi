using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrayManagementApi.Common.Model
{
    public class CATEGORY
    {
        [Key]
        public int ID { get; set; }
        public string NAME { get; set; }
    }
}
