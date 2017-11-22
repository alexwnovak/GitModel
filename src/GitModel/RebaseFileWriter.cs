using System;
using System.Collections.Generic;
using System.Linq;
using GitModel.Internal;

namespace GitModel
{
   /// <summary>
   /// This class can write Git rebase files to disk.
   /// </summary>
   public class RebaseFileWriter : IRebaseFileWriter
   {
      private readonly IFileSystem _fileSystem;

      /// <summary>
      /// Initializes a new instance of the RebaseFileWriter class.
      /// </summary>
      public RebaseFileWriter() : this( new FileSystem() )
      {
      }

      internal RebaseFileWriter( IFileSystem fileSystem )
      {
         _fileSystem = fileSystem;
      }

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
      public void ToFile( string filePath, RebaseDocument document )
      {
         if ( string.IsNullOrEmpty( filePath ) )
         {
            throw new ArgumentException( "File path must not be null or empty", nameof( filePath ) );
         }

         if ( document == null )
         {
            throw new ArgumentException( "Rebase document must not be null", nameof( document ) );
         }

         var allLines = document.Items.Select( i => i.ToString() );

         WriteAllLines( filePath, allLines );
      }

      private void WriteAllLines( string filePath, IEnumerable<string> lines )
      {
         try
         {
            _fileSystem.WriteAllLines( filePath, lines );
         }
         catch ( Exception ex )
         {
            throw new GitModelException( $"Unable to write rebase file to: {filePath}. Refer to the inner exception for details.", ex );
         }
      }
   }
}
