namespace GitModel
{
   /// <summary>
   /// Represents a single item contained in a rebase. There are typically several
   /// of these items involved in a rebase.
   /// </summary>
   public class RebaseItem
   {
      /// <summary>
      /// The kind of action to take for this particular item.
      /// </summary>
      public RebaseAction Action
      {
         get;
         set;
      }

      /// <summary>
      /// The commit hash for the commit being acted upon.
      /// </summary>
      public string CommitHash
      {
         get;
         set;
      }

      /// <summary>
      /// The commit subject for the commit being acted upon.
      /// </summary>
      public string Subject
      {
         get;
         set;
      }

      /// <summary>
      /// Returns a string that represents the current object properties.
      /// </summary>
      /// <returns>A string that contains the current property values.</returns>
      public override string ToString() => $"{Action.ToString().ToLower()} {CommitHash} {Subject}";
   }
}
