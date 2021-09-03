﻿using System;

namespace Tagster.Auth.Exceptions
{
    public abstract class AuthException : Exception
    {
        public abstract string Code { get; }

        protected AuthException(string message) : base(message)
        {
        }
    }
}