using System;
using System.Collections.Generic;
using GitModel.Internal;

namespace GitModel
{
   /// <summary>
   /// This class can parse Git rebase files from disk. It can read each line and read the
   /// rebase action (pick, squash, etc.), the commit hash, and the commit subject.
   /// </summary>
   public class RebaseFileReader : IRebaseFileReader
   {
      private readonly IFileSystem _fileSystem;

      /// <summary>
      /// Initializes a new instance of the RebaseFileReader class.
      /// </summary>
      public RebaseFileReader() : this( new FileSystem() )
      {
      }

      internal RebaseFileReader( IFileSystem fileSystem )
      {
         _fileSystem = fileSystem;
      }

      /// <summary>
      /// Reads a Git rebase file from disk and returns its details in a <seealso cref="RebaseDocument"/> instance.
      /// </summary>
      /// <param name="filePath">The full path to the Git rebase file. This must not be null or empty.</param>
      /// <returns>A <seealso cref="RebaseDocument"/> object that contains the rebase details.</returns>
      /// <exception cref="ArgumentException">Thrown if filePath is null or empty.</exception>
      /// <exception cref="GitModelException">
      /// Thrown if disk access fails for any reason. Refer to the inner exception for details.
      /// </exception>
      public RebaseDocument FromFile( string filePath )
      {
         if ( string.IsNullOrEmpty( filePath ) )
         {
            throw new ArgumentException( "File path must not be null or empty", nameof( filePath ) );
         }

         var allLines = _fileSystem.ReadAllLines( filePath );
         var rebaseItems = new List<RebaseItem>();

         foreach ( string line in allLines )
         {
            int firstSpace = line.IndexOf( ' ' );
            int secondSpace = line.IndexOf( ' ', firstSpace + 1 );

            string firstToken = line.Substring( 0, firstSpace );
            string secondToken = line.Substring( firstSpace + 1, secondSpace - firstSpace - 1 );
            string thirdToken = line.Substring( secondSpace + 1 );

            var rebaseItem = new RebaseItem
            {
               Action = RebaseActionParser.ToRebaseAction( firstToken ),
               CommitHash = secondToken,
               Subject = thirdToken
            };

            rebaseItems.Add( rebaseItem );
         }

         return new RebaseDocument
         {
            Items = rebaseItems.ToArray()
         };
      }
   }
}
