using System;

namespace Ninjato.Common.Exceptions
{
    /// <summary>
    /// Ninjato exception.
    /// </summary>
    public class NinjatoException : Exception
    {
        /// <summary>
        /// Gets the code.
        /// </summary>
        /// <value>The code.</value>
        public string Code { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Ninjato.Common.Exceptions.NinjatoException"/> class.
        /// </summary>
        public NinjatoException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Ninjato.Common.Exceptions.NinjatoException"/> class.
        /// </summary>
        /// <param name="code">Code.</param>
        public NinjatoException(string code) => Code = code;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Ninjato.Common.Exceptions.NinjatoException"/> class.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="args">Arguments.</param>
        public NinjatoException(string message, params object[] args) : this(string.Empty, message, args)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Ninjato.Common.Exceptions.NinjatoException"/> class.
        /// </summary>
        /// <param name="code">Code.</param>
        /// <param name="message">Message.</param>
        /// <param name="args">Arguments.</param>
        public NinjatoException(string code, string message, params object[] args) : this(null, code, message, args)
        { 
        
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Ninjato.Common.Exceptions.NinjatoException"/> class.
        /// </summary>
        /// <param name="innerException">Inner exception.</param>
        /// <param name="message">Message.</param>
        /// <param name="args">Arguments.</param>
        public NinjatoException(Exception innerException, string message, params object[] args) 
            : this(innerException, string.Empty, message, args)
        { 

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Ninjato.Common.Exceptions.NinjatoException"/> class.
        /// </summary>
        /// <param name="innerException">Inner exception.</param>
        /// <param name="code">Code.</param>
        /// <param name="message">Message.</param>
        /// <param name="args">Arguments.</param>
        public NinjatoException(Exception innerException, string code, string message, params object[] args)
                : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }
}
