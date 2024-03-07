using Core.NewAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Positions
    {
        [Identification]
        public Guid PositionId { get; set; }
        [CodeLegal]
        public string PositionCode { get; set; }
        public string PositionName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
