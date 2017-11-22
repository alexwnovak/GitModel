namespace GitModel
{
   /// <summary>
   /// Represents all actions that can be taken for a commit in a rebase.
   /// </summary>
   public enum RebaseAction
   {
      /// <summary>
      /// Applies the commit.
      /// </summary>
      Pick,

      /// <summary>
      /// Applies the commit and edits the commit message.
      /// </summary>
      Reword,

      /// <summary>
      /// Applies the commit, but suspends the rebase to allow further commands.
      /// </summary>
      Edit,

      /// <summary>
      /// Applies the commit, combining it with the previous commit, and edits the commit message.
      /// </summary>
      Squash,

      /// <summary>
      /// Applies the commit, combining it with the previous commit, and discards the commit message.
      /// </summary>
      Fixup,

      /// <summary>
      /// Run the given command contained in the Subject property using the shell.
      /// </summary>
      Exec
   }
}
