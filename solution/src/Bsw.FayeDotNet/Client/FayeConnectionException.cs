// Copyright 2013 BSW Technology Consulting, released under the BSD license - see LICENSING.txt at the top of this repository for details
﻿#region

using System;
using System.Linq;
using System.Linq.Expressions;

#endregion

namespace Bsw.FayeDotNet.Client
{
    public class FayeConnectionException : Exception
    {
        public FayeConnectionException(string message) : base(message)
        {
        }
    }
}