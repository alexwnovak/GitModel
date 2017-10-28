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

      public void FromFile( string filePath )
      {
         if ( string.IsNullOrEmpty( filePath ) )
         {
            throw new ArgumentException( "File path must not be null or empty", nameof( filePath ) );
         }

         if ( !_fileSystem.FileExists( filePath ) )
         {
            throw new FileNotFoundException( $"Couldn't find file: {filePath}" );
         }

         throw new NotImplementedException();
      }
   }
}
