namespace GitModel
{
   /// <summary>
   /// This class contains the file names for each Git operation. Using these names,
   /// you can easily detect what operation (commit vs. rebase, etc.) is being launched.
   /// </summary>
   public static class GitFileNames
   {
      /// <summary>
      /// The name of the file used when committing.
      /// </summary>
      public const string CommitFileName = "COMMIT_EDITMSG";

      /// <summary>
      /// The name of the file used when interactively rebasing.
      /// </summary>
      public const string RebaseFileName = "git-rebase-todo";

      /// <summary>
      /// The name of the file used when editing a hunk from "git add -p".
      /// </summary>
      public const string EditPatchFileName = "addp-hunk-edit.diff";

      /// <summary>
      /// The name of the file used when editing a patch from "git add -e".
      /// </summary>
      public const string AddEditPatchFileName = "ADD_EDIT.patch";
   }
}
