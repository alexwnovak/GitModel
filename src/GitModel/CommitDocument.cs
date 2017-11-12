namespace GitModel
{
   /// <summary>
   /// Represents the data contained in a Git commit.
   /// </summary>
   public class CommitDocument
   {
      /// <summary>
      /// The commit's first line. This describes what the commit is accomplishing, and is often
      /// constrained to 50 or 72 characters.
      /// </summary>
      public string Subject
      {
         get;
         set;
      }

      /// <summary>
      /// The commit's secondary lines. These describe the details of how the commit accomplishes
      /// its goal (described by the <seealso cref="Subject"/> property).
      /// </summary>
      public string[] Body
      {
         get;
         set;
      }

      /// <summary>
      /// Initializes a new instance of the CommitDocument class.
      /// </summary>
      public CommitDocument()
      {
      }
   }
}
