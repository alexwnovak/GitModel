using System;
using System.IO;

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

         var allLines = _fileSystem.ReadAllLines();

         return new CommitDocument
         {
            Subject = allLines[0]
         };
      }
   }
}
