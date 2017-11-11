using TechTalk.SpecFlow;
using FluentAssertions;
using GitModel.AcceptanceTests.ModelObjects;

namespace GitModel.AcceptanceTests.Steps
{
   [Binding]
   public class CommitSharedSteps
   {
      private readonly CommitDocumentObject _commitDocumentObject;

      public CommitSharedSteps( CommitDocumentObject commitDocumentObject )
      {
         _commitDocumentObject = commitDocumentObject;
      }

      [Given( @"the commit subject is ""(.*)""" )]
      public void GivenTheCommitDocumentSubjectIs( string subject )
      {
         _commitDocumentObject.Subject = subject;
      }

      [Given( @"the commit body has the lines ""(.*)""" )]
      public void GivenTheCommitBodyHasTheLines( string[] body )
      {
         _commitDocumentObject.Body = body;
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
         _commitDocumentObject.Load();

         _commitDocumentObject.Body.Should().Contain( bodyLines );
      }

      [Given( @"I write the commit file" )]
      [When( @"I write the commit file" )]
      public void WhenIWriteCommitFile() => _commitDocumentObject.Save();

      [When( @"I read the commit file" )]
      public void WhenIReadTheCommitFile() => _commitDocumentObject.Load();
   }
}
