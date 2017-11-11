using System.IO;
using TechTalk.SpecFlow;
using FluentAssertions;
using GitModel;

namespace GitModel.AcceptanceTests.Steps
{
   [Binding]
   public class CommitFileWriterSteps
   {
      private readonly ScenarioContext _scenarioContext;

      public CommitFileWriterSteps( ScenarioContext scenarioContext )
      {
         _scenarioContext = scenarioContext;
      }

      [Given( @"the commit document subject is ""(.*)""" )]
      public void GivenTheCommitDocumentSubjectIs( string subject )
      {
         var commitDocument = new CommitDocument
         {
            Subject = subject
         };

         _scenarioContext[Keys.CommitDocumentKey] = commitDocument;
      }

      [When( @"I write commit file" )]
      public void WhenIWriteCommitFile()
      {
         string tempFileName = Path.GetTempFileName();
         var commitDocument = (CommitDocument) _scenarioContext[Keys.CommitDocumentKey];

         var commitFileWriter = new CommitFileWriter();

         commitFileWriter.ToFile( tempFileName, commitDocument );
      }

      [Then( @"the commit file subject is ""(.*)""" )]
      public void ThenTheCommitFileSubjectIs( string expectedSubject )
      {
         var commitDocument = (CommitDocument) _scenarioContext[Keys.CommitDocumentKey];

         var commitFileReader = new CommitFileReader();
         var actualCommitDocument = commitFileReader.FromFile( commitDocument.FilePath );

         actualCommitDocument.Subject.Should().Be( expectedSubject );
      }
   }
}
