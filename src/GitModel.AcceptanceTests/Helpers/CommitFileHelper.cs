using System.Collections.Generic;

namespace GitModel.AcceptanceTests.Helpers
{
   internal class CommitFileHelper
   {
      public string Subject
      {
         get;
         set;
      } = string.Empty;

      public string[] Body
      {
         get;
         set;
      } = new string[0];

      private string[] GetRawLines()
      {
         var lines = new List<string>();

         lines.Add( Subject );
         lines.Add( "" );
         lines.AddRange( Body );
         lines.Add( "# Please enter the commit message for your changes. Lines starting" );
         lines.Add( "# with '#' will be ignored, and an empty message aborts the commit." );
         lines.Add( "#" );
         lines.Add( "# On branch master" );
         lines.Add( "# Changes to be committed:" );
         lines.Add( "# deleted:    SomeFile" );
         lines.Add( "#" );
         lines.Add( "# Changes not staged for commit:" );
         lines.Add( "# modified:   src/GitModel.AcceptanceTests/GitModel.AcceptanceTests.csproj" );
         lines.Add( "#" );
         lines.Add( "# Untracked files:" );
         lines.Add( "# src/.vs/" );
         lines.Add( "# src/GitModel.AcceptanceTests/Helpers/" );
         lines.Add( "# src/GitModel/FileSystem.cs" );
         lines.Add( "#" );

         return lines.ToArray();
      }

      public string Save()
      {
         var lines = GetRawLines();

         return FileHelper.WriteTempFile( lines );
      }
   }
}
