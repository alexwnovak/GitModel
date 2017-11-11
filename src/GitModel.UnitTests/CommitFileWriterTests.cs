using System.Collections.Generic;
using System.Linq;
using Xunit;
using Moq;
using GitModel;

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
   }
}
