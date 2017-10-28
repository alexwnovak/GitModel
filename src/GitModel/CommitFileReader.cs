using System;
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

         var allLines = _fileSystem.ReadAllLines().Where( l => !l.StartsWith( "#" ) ).ToArray();

         string subject = allLines.First( l => !string.IsNullOrEmpty( l ) );

         return new CommitDocument
         {
            Subject = subject
         };
      }
   }
}
