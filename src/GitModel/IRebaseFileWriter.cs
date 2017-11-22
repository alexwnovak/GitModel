using System;

namespace GitModel
{
   /// <summary>
   /// This class can write Git rebase files to disk.
   /// </summary>
   public interface IRebaseFileWriter
   {
      /// <summary>
      /// Writes a <seealso cref="RebaseDocument"/> instance to the given file path.
      /// </summary>
      /// <param name="filePath">
      /// The full path and file name to write the <seealso cref="RebaseDocument"/> instance. This must
      /// not be null or empty.</param>
      /// <param name="document">
      /// The object that contains the rebase's details. This must not be null, and its contents
      /// must not be null.
      /// </param>
      /// <exception cref="ArgumentException">
      /// Thrown if either the filePath or document arguments are null.
      /// </exception>
      /// <exception cref="GitModelException">
      /// Thrown if disk access fails for any reason. Refer to the inner exception for details.
      /// </exception>
      void ToFile( string filePath, RebaseDocument document );
   }
}