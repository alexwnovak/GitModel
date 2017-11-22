namespace GitModel
{
   /// <summary>
   /// Represents the data contained in a Git rebase.
   /// </summary>
   public class RebaseDocument
   {
      /// <summary>
      /// A collection of items that represent the commits and how they're being applied.
      /// </summary>
      public RebaseItem[] Items
      {
         get;
         set;
      }
   }
}
