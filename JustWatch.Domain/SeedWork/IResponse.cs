using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustWatch.Domain.SeedWork
{
    public interface IResponse
    {
        bool IsSuccess { get; }
        string Message { get; }
    }
}
