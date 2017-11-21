using System.IO;

namespace GitModel.AcceptanceTests.ModelObjects
{
   public class RebaseDocumentObject
   {
      private readonly string _tempFileName = Path.GetTempFileName();
      private RebaseDocument _rebaseDocument = new RebaseDocument();

      public RebaseItem[] Items
      {
         get => _rebaseDocument.Items;
         set => _rebaseDocument.Items = value;
      }

      public void Load()
      {
         var rebaseFileReader = new RebaseFileReader();

         _rebaseDocument = rebaseFileReader.FromFile( _tempFileName );
      }

      public void Save()
      {
      }
   }
}
