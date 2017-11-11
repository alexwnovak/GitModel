using System;
using System.Collections.Generic;

namespace GitModel
{
   public class CommitFileWriter
   {
      private readonly IFileSystem _fileSystem;

      public CommitFileWriter() : this( new FileSystem() )
      {
      }

      internal CommitFileWriter( IFileSystem fileSystem )
      {
         _fileSystem = fileSystem;
      }

      public void ToFile( string filePath, CommitDocument document )
      {
         var lines = new List<string>();

         lines.Add( document.Subject );
         
         _fileSystem.WriteAllLines( filePath, lines );
      }
   }
}
