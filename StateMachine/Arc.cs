﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StateMachine.Callbacks;
using StateMachine.Exceptions;

namespace StateMachine
{
    public class Arc
    {
        private List<ArcCallbackInvoker> _transitCallbacks;

        public State Source { get; private set; }
        public State Target { get; private set; }
        public bool IsUnlinked
        {
            get
            {
                return Source == null || Target == null;
            }
        }

        public Arc(State source, State target)
        {
            Source = source;
            Target = target;

            _transitCallbacks = new List<ArcCallbackInvoker>();

            if (IsUnlinked)
            {
                throw new StateMachineException(ErrorCodes.InvalidArc, StateMachineException.MakeArcName(source.Name, target.Name));
            }
        }

        public void AddTransitionCallback(ArcCallback method)
        {
            ArcCallbackInvoker aci = new ArcCallbackInvoker(method);
            _transitCallbacks.Add(aci);
        }

        public void CallTransitionCallbacks()
        {
            foreach (ArcCallbackInvoker aci in _transitCallbacks)
            {
                aci.Invoke(Source.Name, Target.Name);
            }
        }
    }
}
