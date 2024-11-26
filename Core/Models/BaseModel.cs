using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int CreatedBy { get; set; }
        public DateOnly CreatedOn { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public int? UpdatedBy { get; set; }
        public DateOnly? UpdetedOn { get; set; }
        public int DeletedBy { get; set; }
        public DateOnly DeletedOn { get; set; }
    }
}
