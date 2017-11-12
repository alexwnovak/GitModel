using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using GitModel.Internal;

namespace GitModel
{
   /// <summary>
   /// This class can parse Git commit files from disk. It can read the subject line, as well as
   /// secondary notes (the body).
   /// </summary>
   public class CommitFileReader : ICommitFileReader
   {
      private readonly IFileSystem _fileSystem;

      /// <summary>
      /// Initializes a new instance of the CommitFileReader class.
      /// </summary>
      public CommitFileReader() : this( new FileSystem() )
      {
      }

      internal CommitFileReader( IFileSystem fileSystem )
      {
         _fileSystem = fileSystem;
      }

      private static TextReader GetTextReader( IEnumerable<string> lines ) => 
         new StringReader( string.Join( Environment.NewLine, lines ) );

      private static IEnumerable<string> OmitComments( IEnumerable<string> lines ) =>
         lines.Where( l => !l.StartsWith( "#" ) );

      private IEnumerable<string> GetCommitFileLines( string filePath )
      {
         string[] allLines;

         try
         {
            allLines = _fileSystem.ReadAllLines( filePath );
         }
         catch ( Exception ex )
         {
            throw new GitModelException( $"Unable to read commit file: {filePath}. Refer to the inner exception for details.", ex );
         }

         return OmitComments( allLines );
      }

      /// <summary>
      /// Reads a Git commit file from disk and returns its details in a <seealso cref="CommitDocument"/> instance.
      /// </summary>
      /// <param name="filePath">The full path to the Git commit file. This must not be null or empty.</param>
      /// <returns>A <seealso cref="CommitDocument"/> object that contains the commit details.</returns>
      /// <exception cref="ArgumentException">Thrown if filePath is null or empty.</exception>
      /// <exception cref="GitModelException">
      /// Thrown if disk access fails for any reason. Refer to the inner exception for details.
      /// </exception>
      public CommitDocument FromFile( string filePath )
      {
         if ( string.IsNullOrEmpty( filePath ) )
         {
            throw new ArgumentException( "File path must not be null or empty", nameof( filePath ) );
         }

         var lines = GetCommitFileLines( filePath );

         string subject = string.Empty;
         var body = new List<string>();

         bool hasFoundSubject = false;
         bool hasStartedBody = false;

         using ( var textReader = GetTextReader( lines ) )
         {
            while ( textReader.Peek() > 0 )
            {
               string line = textReader.ReadLine();

               if ( !hasFoundSubject )
               {
                  if ( string.IsNullOrEmpty( line ) )
                  {
                     continue;
                  }

                  hasFoundSubject = true;
                  subject = line;
               }
               else if ( !hasStartedBody )
               {
                  if ( string.IsNullOrEmpty( line ) )
                  {
                     continue;
                  }

                  hasStartedBody = true;
                  body.Add( line );
               }
               else if ( hasStartedBody )
               {
                  body.Add( line );
               }
            }
         }

         return new CommitDocument
         {
            Subject = subject,
            Body = body.ToArray()
         };
      }
   }
}
