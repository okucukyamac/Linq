using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqBasics.Abstract
{
    internal abstract class AbstractCourse
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public int Rank { get; set; }
    }

    class FreeCourse : AbstractCourse
    {

    }

    class PaidCourse : AbstractCourse
    {
        public decimal Fees { get; set; }
    }
}
