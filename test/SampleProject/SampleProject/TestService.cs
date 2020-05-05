using System;

namespace SampleProject
{
    public class TestService
    {
        public bool GetTrue()
        {
            return true;
        }

        public bool GetFalse()
        {
            return false;
        }

        public bool GetException()
        {
            throw new Exception("Pretty good exception");
        }
    }
}