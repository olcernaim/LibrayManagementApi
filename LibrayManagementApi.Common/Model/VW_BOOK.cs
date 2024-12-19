using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrayManagementApi.Common.Model
{
    public class VW_BOOK
    {
        [Key]
        public int ID { get; set; }
        public string NAME { get; set; }
        public int NUMBEROFPAGES { get; set; }
        public string PUBLISHERNAME { get; set; }
        public string CATEGORYNAME { get; set; }
        public string AUTHORNAME { get; set; }
        public DateTime DATEOFPUBLICATIONS { get; set; }
    }
}
