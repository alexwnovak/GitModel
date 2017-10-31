using TechTalk.SpecFlow;

namespace GitModel.AcceptanceTests.Steps
{
   [Binding]
   public class CommitFileWriterSteps
   {
      [Given( @"the commit document subject is ""(.*)""" )]
      public void GivenTheCommitDocumentSubjectIs( string subject )
      {
         ScenarioContext.Current.Pending();
      }

      [When( @"I write commit file" )]
      public void WhenIWriteCommitFile()
      {
         ScenarioContext.Current.Pending();
      }

      [Then( @"the commit file subject is ""(.*)""" )]
      public void ThenTheCommitFileSubjectIs( string expectedSubject )
      {
         ScenarioContext.Current.Pending();
      }
   }
}
