using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;
using Moq;
using GitModel;
using GitModel.Internal;

namespace GitModel.UnitTests
{
   public class CommitFileWriterTests
   {
      [Fact]
      public void ToFile_CommitDocumentHasSubject_SubjectIsWritten()
      {
         const string filePath = "COMMIT_EDITMSG";
         const string subject = "Commit subject";

         var fileSystemMock = new Mock<IFileSystem>();

         var commitDocument = new CommitDocument
         {
            Subject = subject
         };

         var commitFileWriter = new CommitFileWriter( fileSystemMock.Object );

         commitFileWriter.ToFile( filePath, commitDocument );

         fileSystemMock.Verify( fs => fs.WriteAllLines( filePath, It.Is<IEnumerable<string>>( c =>
            c.Contains( subject ) ) ), Times.Once() );
      }

      [Fact]
      public void ToFile_CommitDocumentHasSubjectAndBody_BodyIsWritten()
      {
         const string filePath = "COMMIT_EDITMSG";
         var body = new[]
         {
            "Line 1",
            "Line 2"
         };

         var fileSystemMock = new Mock<IFileSystem>();
         fileSystemMock.Setup( fs => fs.WriteAllLines( It.IsAny<string>(), It.IsAny<IEnumerable<string>>() ) )
            .Callback<string, IEnumerable<string>>( Assert );

         var commitDocument = new CommitDocument
         {
            Subject = "DoesntMatter",
            Body = body
         };

         var commitFileWriter = new CommitFileWriter( fileSystemMock.Object );

         commitFileWriter.ToFile( filePath, commitDocument );

         void Assert( string actualFilePath, IEnumerable<string> actualContents )
         {
            actualContents.Should().Contain( body );
         }
      }
   }
}
