using System;

namespace GitModel
{
   /// <summary>
   /// This class can parse Git commit files from disk. It can read the subject line, as well as
   /// secondary notes (the body).
   /// </summary>
   /// <param name="filePath">The path to the Git commit file on disk. This must not be null or empty</param>
   /// <exception cref="ArgumentException">Thrown if filePath is null or empty.</exception>
   public interface ICommitFileReader
   {
      CommitDocument FromFile( string filePath );
   }
}
