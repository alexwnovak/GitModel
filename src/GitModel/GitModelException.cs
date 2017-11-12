using System;

namespace GitModel
{
   /// <summary>
   /// Represents errors that occur during GitModel execution. Refer to the
   /// inner exception for details.
   /// </summary>
   public class GitModelException : Exception
   {
      /// <summary>
      /// Initializes a new instance of the GitModel.GitModelException class.
      /// </summary>
      public GitModelException()
      {
      }

      /// <summary>
      /// Initializes a new instance of the GitModel.GitModelException class.
      /// </summary>
      /// <param name="message">The message that describes the error.</param>
      public GitModelException( string message ) : base( message )
      {
      }

      /// <summary>
      /// Initializes a new instance of the GitModel.GitModelException class.
      /// </summary>
      /// <param name="message">The message that describes the error.</param>
      /// <param name="inner">
      /// The exception that is the cause of the current exception, or a null reference
      /// if no inner exception is specified.
      /// </param>
      public GitModelException( string message, Exception inner ) : base( message, inner )
      {
      }
   }
}
