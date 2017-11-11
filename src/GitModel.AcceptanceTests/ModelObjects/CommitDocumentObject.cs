using System.IO;
using GitModel;

namespace GitModel.AcceptanceTests.ModelObjects
{
   internal class CommitDocumentObject
   {
      private readonly string _tempFileName = Path.GetTempFileName();
      private CommitDocument _commitDocument = new CommitDocument();

      public string Subject
      {
         get => _commitDocument.Subject;
         set => _commitDocument.Subject = value;
      }

      public string[] Body
      {
         get => _commitDocument.Body;
         set => _commitDocument.Body = value;
      }

      public void Load()
      {
         var commitFileReader = new CommitFileReader();

         _commitDocument = commitFileReader.FromFile( _tempFileName );
      }

      public void Save()
      {
         var commitFileWriter = new CommitFileWriter();

         commitFileWriter.ToFile( _tempFileName, _commitDocument );
      }
   }
}
