namespace GitModel
{
   /// <summary>
   /// Represents the data contained in a Git commit.
   /// </summary>
   public class CommitDocument
   {
      /// <summary>
      /// A pre-made CommitDocument instance that has an empty subject and body.
      /// This can be used with the <seealso cref="CommitFileWriter"/> to write an
      /// empty commit file, signaling to Git that the commit should be aborted.
      /// </summary>
      public static readonly CommitDocument Empty = new CommitDocument( string.Empty, new string[0] );

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

      /// <summary>
      /// Initializes a new instance of the CommitDocument class.
      /// </summary>
      /// <param name="subject">The commit subject.</param>
      public CommitDocument( string subject )
      {
         Subject = subject;
      }

      /// <summary>
      /// Initializes a new instance of the CommitDocument class.
      /// </summary>
      /// <param name="subject">The commit subject.</param>
      /// <param name="body">
      /// The commit body. These are the extra commit notes that describe
      /// the actual contents of the commit.
      /// </param>
      public CommitDocument( string subject, string[] body ) : this( subject )
      {
         Body = body;
      }

      /// <summary>
      /// Clears the document's data, resetting it to empty values.
      /// </summary>
      public void Clear()
      {
         Subject = string.Empty;
         Body = new string[0];
      }
   }
}
