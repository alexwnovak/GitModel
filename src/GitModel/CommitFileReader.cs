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
   /// <param name="filePath">The path to the Git commit file on disk. This must not be null or empty</param>
   /// <exception cref="ArgumentException">Thrown if filePath is null or empty.</exception>
   public class CommitFileReader : ICommitFileReader
   {
      private readonly IFileSystem _fileSystem;

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

      private IEnumerable<string> GetCommitFileLines( string filePath ) =>
         OmitComments( _fileSystem.ReadAllLines( filePath ) );

      public CommitDocument FromFile( string filePath )
      {
         if ( string.IsNullOrEmpty( filePath ) )
         {
            throw new ArgumentException( "File path must not be null or empty", nameof( filePath ) );
         }

         if ( !_fileSystem.FileExists( filePath ) )
         {
            throw new FileNotFoundException( $"Couldn't find file: {filePath}" );
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
