﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StateMachine.EventArgs
{
    public class TransitedEventArgs<TState> : AbstractStateEventArgs<TState>
    {
        public TransitedEventArgs(TState state)
            : base(state)
        {
        }
    }
}
