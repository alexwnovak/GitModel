using System;
using System.Collections.Generic;
using GitModel.Internal;

namespace GitModel
{
   /// <summary>
   /// 
   /// </summary>
   public class RebaseFileReader
   {
      private readonly IFileSystem _fileSystem;

      internal RebaseFileReader( IFileSystem fileSystem )
      {
         _fileSystem = fileSystem;
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="filePath"></param>
      /// <returns></returns>
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
            var tokens = line.Split( ' ' );

            var rebaseItem = new RebaseItem
            {
               Action = RebaseActionParser.ToRebaseAction( tokens[0] ),
               CommitHash = tokens[1],
               Subject = tokens[2]
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
