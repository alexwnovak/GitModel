using System;

namespace GitModel
{
   /// <summary>
   /// This class can parse Git commit files from disk. It can read the subject line, as well as
   /// secondary notes (the body).
   /// </summary>
   public interface ICommitFileReader
   {
      /// <summary>
      /// Reads a Git commit file from disk.
      /// </summary>
      /// <param name="filePath">The full path to the Git commit file. This must not be null or empty.</param>
      /// <returns>A <seealso cref="CommitDocument"/> object that contains the commit details.</returns>
      /// <exception cref="ArgumentException">Thrown if filePath is null or empty.</exception>
      /// <exception cref="GitModelException">
      /// Thrown if disk access fails for any reason. Refer to the inner exception for details.
      /// </exception>
      CommitDocument FromFile( string filePath );
   }
}
