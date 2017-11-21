using System;
using GitModel.Internal;

namespace GitModel
{
   /// <summary>
   /// 
   /// </summary>
   public class RebaseFileWriter
   {
      private readonly IFileSystem _fileSystem;

      internal RebaseFileWriter( IFileSystem fileSystem )
      {
         _fileSystem = fileSystem;
      }

      public void ToFile( string filePath )
      {
         if ( string.IsNullOrEmpty( filePath ) )
         {
            throw new ArgumentException( "File path must not be null or empty", nameof( filePath ) );
         }

         throw new System.NotImplementedException();
      }
   }
}
