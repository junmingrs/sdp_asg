using System;
using System.Collections.Generic;
using System.Text;

namespace SDP_ASG
{
    public interface ICommand
    {
        public Order execute();
    }
}
