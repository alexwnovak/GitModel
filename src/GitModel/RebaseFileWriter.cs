﻿using System;
using System.Linq;
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

      public void ToFile( string filePath, RebaseDocument document )
      {
         if ( string.IsNullOrEmpty( filePath ) )
         {
            throw new ArgumentException( "File path must not be null or empty", nameof( filePath ) );
         }

         if ( document == null )
         {
            throw new ArgumentException( "Rebase document must not be null", nameof( document ) );
         }

         var allLines = document.Items.Select( i => i.ToString() );

         _fileSystem.WriteAllLines( filePath, allLines );
      }
   }
}
