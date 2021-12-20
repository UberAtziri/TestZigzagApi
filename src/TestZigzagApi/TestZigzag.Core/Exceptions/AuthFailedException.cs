using System;

namespace TestZigzag.Core.Exceptions
{
    public class AuthFailedException : Exception
    {
        private const string DefaultMessage = "Authentication failed.";
        private const string UserNotFoundOrWrongPasswordMessage = "There is no such user {0} or password is incorrect";

        public AuthFailedException() : base(DefaultMessage)
        {
        }
        
        public AuthFailedException(string userName) : base(string.Format(UserNotFoundOrWrongPasswordMessage, userName))
        {
        }
    }
}