using System.IO;
using TechTalk.SpecFlow;
using FluentAssertions;
using GitModel;
using GitModel.AcceptanceTests.ModelObjects;

namespace GitModel.AcceptanceTests.Steps
{
   [Binding]
   public class CommitFileWriterSteps
   {
      private readonly CommitDocumentObject _commitDocumentObject = new CommitDocumentObject();
      private readonly ScenarioContext _scenarioContext;

      public CommitFileWriterSteps( ScenarioContext scenarioContext )
      {
         _scenarioContext = scenarioContext;
      }

      [Given( @"the commit document subject is ""(.*)""" )]
      public void GivenTheCommitDocumentSubjectIs( string subject )
      {
         _commitDocumentObject.Subject = subject;
      }

      [Given( @"I write the commit file" )]
      public void GivenIWriteTheCommitFile() => WhenIWriteCommitFile();

      [When( @"I write commit file" )]
      public void WhenIWriteCommitFile()
      {
         _commitDocumentObject.Save();
      }

      [Then( @"the commit file subject is ""(.*)""" )]
      public void ThenTheCommitFileSubjectIs( string expectedSubject )
      {
         _commitDocumentObject.Load();

         _commitDocumentObject.Subject.Should().Be( expectedSubject );
      }

      [Then( @"the commit file subject body has the lines ""(.*)""" )]
      public void ThenTheCommitFileSubjectBodyHasTheLines( string[] bodyLines )
      {
         string tempFileName = (string) _scenarioContext[Keys.CommitFilePathKey];

         var allLines = File.ReadAllLines( tempFileName );
      }
   }
}
