using System;
using System.Collections.Generic;
using System.Text;

namespace Online_Shopping_Domain.Entities
{
   public class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }

        public DateTime ModifiedOn { get; set; }

        public string ModifiedBy { get; set; }


    }
}
