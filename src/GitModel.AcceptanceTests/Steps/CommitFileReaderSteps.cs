using FluentAssertions;
using TechTalk.SpecFlow;
using GitModel.AcceptanceTests.Helpers;

namespace GitModel.AcceptanceTests.Steps
{
   [Binding]
   public class CommitFileReaderSteps
   {
      private const string _commitFilePathKey = "CommitFilePath";
      private const string _commitDocumentKey = "CommitDocument";

      [AfterScenario]
      public void ScenarioCleanup()
      {
         if ( ScenarioContext.Current.TryGetValue( _commitFilePathKey, out string commitFilePath ) )
         {
            FileHelper.DeleteFile( commitFilePath );
         }
      }

      [Given( @"the commit file has subject ""(.*)""" )]
      public void GivenTheCommitFileHasSubject( string subject )
      {
         string commitFilePath = FileHelper.WriteTempFile(
            subject,
            "",
            "# Please enter the commit message for your changes. Lines starting",
            "# with '#' will be ignored, and an empty message aborts the commit.",
            "#",
            "# On branch master",
            "# Changes to be committed:",
            "# deleted:    SomeFile",
            "#",
            "# Changes not staged for commit:",
            "# modified:   src/GitModel.AcceptanceTests/GitModel.AcceptanceTests.csproj",
            "#",
            "# Untracked files:",
            "# src/.vs/",
            "# src/GitModel.AcceptanceTests/Helpers/",
            "# src/GitModel/FileSystem.cs",
            "#"
         );

         ScenarioContext.Current[_commitFilePathKey] = commitFilePath;
      }

      [When( @"I read the commit file" )]
      public void WhenIReadTheCommitFile()
      {
         string commitFilePath = (string) ScenarioContext.Current[_commitFilePathKey];

         var commitFileReader = new CommitFileReader();
         var commitDocument = commitFileReader.FromFile( commitFilePath );

         ScenarioContext.Current[_commitDocumentKey] = commitDocument;
      }

      [Then( @"the subject should be ""(.*)""" )]
      public void ThenTheSubjectShouldBe( string subject )
      {
         var commitDocument = (CommitDocument) ScenarioContext.Current[_commitDocumentKey];

         commitDocument.Subject.Should().Be( subject );
      }
   }
}
