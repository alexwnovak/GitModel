using TechTalk.SpecFlow;
using FluentAssertions;
using GitModel.AcceptanceTests.Helpers;

namespace GitModel.AcceptanceTests.Steps
{
   [Binding]
   public class CommitFileReaderSteps
   {
      //[AfterScenario]
      //public void ScenarioCleanup()
      //{
      //   if ( _scenarioContext.TryGetValue( Keys.CommitFilePathKey, out string commitFilePath ) )
      //   {
      //      FileHelper.DeleteFile( commitFilePath );
      //   }
      //}

      //[Given( @"the commit subject is ""(.*)""" )]
      //public void GivenTheCommitFileHasSubject( string subject )
      //{
      //   var commitFileHelper = new CommitFileHelper
      //   {
      //      Subject = subject
      //   };

      //   _scenarioContext[Keys.CommitFileHelperKey] = commitFileHelper;
      //}

      //[Given( @"the commit body has the lines ""(.*)""" )]
      //public void GivenTheCommitFileHasBody( string[] body )
      //{
      //   var commitFileHelper = (CommitFileHelper) _scenarioContext[Keys.CommitFileHelperKey];

      //   commitFileHelper.Body = body;
      //}

      //[Given( @"the commit file exists" )]
      //public void TheCommitFileExists()
      //{
      //   var commitFileHelper = (CommitFileHelper) _scenarioContext[Keys.CommitFileHelperKey];

      //   string commitFilePath = commitFileHelper.Save();

      //   _scenarioContext[Keys.CommitFilePathKey] = commitFilePath;
      //}

      ////[When( @"I read the commit file" )]
      ////public void WhenIReadTheCommitFile()
      ////{
      ////   string commitFilePath = (string) _scenarioContext[Keys.CommitFilePathKey];

      ////   var commitFileReader = new CommitFileReader();
      ////   var commitDocument = commitFileReader.FromFile( commitFilePath );

      ////   _scenarioContext[Keys.CommitDocumentKey] = commitDocument;
      ////}

      //[Then( @"the subject should be ""(.*)""" )]
      //public void ThenTheSubjectShouldBe( string subject )
      //{
      //   var commitDocument = (CommitDocument) _scenarioContext[Keys.CommitDocumentKey];

      //   commitDocument.Subject.Should().Be( subject );
      //}

      //[Then( @"the body should be the lines ""(.*)""" )]
      //public void ThenTheBodyShouldBeTheLines( string[] expectedBodyLines )
      //{
      //   var commitDocument = (CommitDocument) _scenarioContext[Keys.CommitDocumentKey];

      //   commitDocument.Body.Should().BeEquivalentTo( expectedBodyLines );
      //}
   }
}
