using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GitModel
{
   public class CommitFileReader
   {
      private readonly IFileSystem _fileSystem;

      public CommitFileReader( IFileSystem fileSystem )
      {
         _fileSystem = fileSystem;
      }

      private static TextReader GetTextReader( IEnumerable<string> lines ) => 
         new StringReader( string.Join( "\r\n", lines ) );

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
