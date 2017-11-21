using System.IO;

namespace GitModel.AcceptanceTests.ModelObjects
{
   public class RebaseDocumentObject
   {
      private readonly string _tempFileName = Path.GetTempFileName();
      private readonly RebaseDocument _rebaseDocument = new RebaseDocument();

      public RebaseItem[] Items
      {
         get => _rebaseDocument.Items;
         set => _rebaseDocument.Items = value;
      }

      public void Load()
      {
      }

      public void Save()
      {
      }
   }
}
