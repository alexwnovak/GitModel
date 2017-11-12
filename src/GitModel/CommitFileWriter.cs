using System;
using System.Collections.Generic;
using GitModel.Internal;

namespace GitModel
{
   /// <summary>
   /// This class can write Git commit files to disk.
   /// </summary>
   public class CommitFileWriter : ICommitFileWriter
   {
      private readonly IFileSystem _fileSystem;

      /// <summary>
      /// Initializes a new instance of the CommitFileWriter class.
      /// </summary>
      public CommitFileWriter() : this( new FileSystem() )
      {
      }

      internal CommitFileWriter( IFileSystem fileSystem )
      {
         _fileSystem = fileSystem;
      }

      /// <summary>
      /// Writes a <seealso cref="CommitDocument"/> instance to the given file path.
      /// </summary>
      /// <param name="filePath">
      /// The full path and file name to write the <seealso cref="CommitDocument"/> instance. This must
      /// not be null or empty.</param>
      /// <param name="document">
      /// The object that contains the commit's details. This must not be null.
      /// </param>
      /// <exception cref="ArgumentException">
      /// Thrown if either the filePath or document arguments are null.
      /// </exception>
      /// <exception cref="GitModelException">
      /// Thrown if disk access fails for any reason. Refer to the inner exception for details.
      /// </exception>
      public void ToFile( string filePath, CommitDocument document )
      {
         if ( string.IsNullOrEmpty( filePath ) )
         {
            throw new ArgumentException( "File path must not be null or empty", nameof( filePath ) );
         }

         if ( document == null )
         {
            throw new ArgumentException( "Commit document must not be null", nameof( document ) );
         }

         var lines = new List<string>
         {
            document.Subject
         };

         if ( document.Body != null )
         {
            lines.Add( string.Empty );
            lines.AddRange( document.Body );
         }

         _fileSystem.WriteAllLines( filePath, lines );
      }
   }
}
