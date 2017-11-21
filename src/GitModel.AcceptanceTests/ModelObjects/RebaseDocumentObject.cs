namespace GitModel.AcceptanceTests.ModelObjects
{
   public class RebaseDocumentObject
   {
      private readonly RebaseDocument _rebaseDocument = new RebaseDocument();

      public RebaseItem[] RebaseItems
      {
         get => _rebaseDocument.Items;
         set => _rebaseDocument.Items = value;
      }
   }
}
