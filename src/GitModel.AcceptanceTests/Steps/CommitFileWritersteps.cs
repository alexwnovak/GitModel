using TechTalk.SpecFlow;

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
         _scenarioContext.Pending();
      }

      [When( @"I write commit file" )]
      public void WhenIWriteCommitFile()
      {
         _scenarioContext.Pending();
      }

      [Then( @"the commit file subject is ""(.*)""" )]
      public void ThenTheCommitFileSubjectIs( string expectedSubject )
      {
         _scenarioContext.Pending();
      }
   }
}
