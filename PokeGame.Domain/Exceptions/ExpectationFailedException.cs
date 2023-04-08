namespace PokeGame.Domain.Exceptions
{
    public class ExpectationFailedException : Exception
    {
        public ExpectationFailedException(string requestFailing) : base($"{requestFailing} failed unexpectedly.") { }
    }
}
