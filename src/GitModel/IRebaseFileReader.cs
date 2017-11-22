using System;

namespace GitModel
{
   /// <summary>
   /// This class can parse Git rebase files from disk. It can read each line and read the
   /// rebase action (pick, squash, etc.), the commit hash, and the commit subject.
   /// </summary>
   public interface IRebaseFileReader
   {
      /// <summary>
      /// Reads a Git rebase file from disk and returns its details in a <seealso cref="RebaseDocument"/> instance.
      /// </summary>
      /// <param name="filePath">The full path to the Git rebase file. This must not be null or empty.</param>
      /// <returns>A <seealso cref="RebaseDocument"/> object that contains the rebase details.</returns>
      /// <exception cref="ArgumentException">Thrown if filePath is null or empty.</exception>
      /// <exception cref="GitModelException">
      /// Thrown if disk access fails for any reason. Refer to the inner exception for details.
      /// </exception>
      RebaseDocument FromFile( string filePath );
   }
}
