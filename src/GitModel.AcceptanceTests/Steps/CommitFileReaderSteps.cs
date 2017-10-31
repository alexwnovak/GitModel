using TechTalk.SpecFlow;
using FluentAssertions;
using GitModel.AcceptanceTests.Helpers;

namespace GitModel.AcceptanceTests.Steps
{
   [Binding]
   public class CommitFileReaderSteps
   {
      private const string _commitFilePathKey = "CommitFilePath";
      private const string _commitDocumentKey = "CommitDocument";
      private const string _commitFileHelperKey = "CommitFileHelper";

      [StepArgumentTransformation]
      public string[] TransformToListOfString( string commaSeparatedList ) =>
         commaSeparatedList.Split( ',' );

      [AfterScenario]
      public void ScenarioCleanup()
      {
         if ( ScenarioContext.Current.TryGetValue( _commitFilePathKey, out string commitFilePath ) )
         {
            FileHelper.DeleteFile( commitFilePath );
         }
      }

      [Given( @"the commit subject is ""(.*)""" )]
      public void GivenTheCommitFileHasSubject( string subject )
      {
         var commitFileHelper = new CommitFileHelper
         {
            Subject = subject
         };

         ScenarioContext.Current[_commitFileHelperKey] = commitFileHelper;
      }

      [Given( @"the commit body has the lines ""(.*)""" )]
      public void GivenTheCommitFileHasBody( string[] body )
      {
         var commitFileHelper = (CommitFileHelper) ScenarioContext.Current[_commitFileHelperKey];

         commitFileHelper.Body = body;
      }

      [Given( @"the commit file exists" )]
      public void TheCommitFileExists()
      {
         var commitFileHelper = (CommitFileHelper) ScenarioContext.Current[_commitFileHelperKey];

         string commitFilePath = commitFileHelper.Save();

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

      [Then( @"the body should be the lines ""(.*)""" )]
      public void ThenTheBodyShouldBeTheLines( string[] expectedBodyLines )
      {
         var commitDocument = (CommitDocument) ScenarioContext.Current[_commitDocumentKey];

         commitDocument.Body.Should().BeEquivalentTo( expectedBodyLines );
      }
   }
}
