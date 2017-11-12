using System;
using System.Collections.Generic;
using GitModel.Internal;

namespace GitModel
{
   public class CommitFileWriter : ICommitFileWriter
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
         if ( string.IsNullOrEmpty( filePath ) )
         {
            throw new ArgumentException( "File path must not be null or empty", nameof( filePath ) );
         }

         if ( document == null )
         {
            throw new ArgumentException( "Commit document must not be null", nameof( document ) );
         }

         var lines = new List<string>
         {
            document.Subject
         };

         if ( document.Body != null )
         {
            lines.Add( string.Empty );
            lines.AddRange( document.Body );
         }

         _fileSystem.WriteAllLines( filePath, lines );
      }
   }
}
