using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustWatch.Domain.SeedWork
{
    public class BaseJustWatchEntity
    {
        public int Id { get; private set; }
        public DateTime CreateDate { get; private set; }
        public DateTime UpdateDate { get; private set; }

    }
}
