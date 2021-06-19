using System;

namespace CadastroDePessoa.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
