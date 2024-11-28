using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrayManagementApi.Common.Model
{
    public class BOOK
    {
        [Key]
        public int ID { get; set; }
        public string NAME { get; set; }
        public int NUMBEROFPAGES { get; set; }
        public int PUBLISHERID { get; set; }
        public int CATEGORYID { get; set; }
        public int AUTHORID { get; set; }
        public DateTime DATEOFPUBLICATIONS { get; set; }
    }
}
