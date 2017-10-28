using System;
using System.IO;
using Xunit;
using FluentAssertions;
using Moq;

namespace GitModel.UnitTests
{
   public class CommitFileReaderTests
   {
      [Fact]
      public void FromFile_FilePathIsNull_ThrowsArgumentException()
      {
         var commitFileReader = new CommitFileReader( Mock.Of<IFileSystem>() );

         Action fromFile = () => commitFileReader.FromFile( null );

         fromFile.ShouldThrow<ArgumentException>();
      }

      [Fact]
      public void FromFile_FilePathIsEmptyString_ThrowsArgumentException()
      {
         var commitFileReader = new CommitFileReader( Mock.Of<IFileSystem>() );

         Action fromFile = () => commitFileReader.FromFile( string.Empty );

         fromFile.ShouldThrow<ArgumentException>();
      }

      [Fact]
      public void FromFile_FilePathDoesNotExist_ThrowsFileNotFoundException()
      {
         const string filePath = "DoesntMatter";

         var fileSystemMock = new Mock<IFileSystem>();
         fileSystemMock.Setup( fs => fs.FileExists( filePath ) ).Returns( false );

         var commitFileReader = new CommitFileReader( fileSystemMock.Object );

         Action fromFile = () => commitFileReader.FromFile( filePath );

         fromFile.ShouldThrow<FileNotFoundException>();
      }

      [Fact]
      public void FromFile_CommitFileHasSubject_PopulatesSubject()
      {
         const string filePath = "DoesntMatter";
         const string subject = "DoesntMatter";

         // Arrange

         var fileSystemMock = new Mock<IFileSystem>();
         fileSystemMock.Setup( fs => fs.FileExists( filePath ) ).Returns( true );
         fileSystemMock.Setup( fs => fs.ReadAllLines() ).Returns( new[] { subject } );

         // Act

         var commitFileReader = new CommitFileReader( fileSystemMock.Object );

         var commitDocument = commitFileReader.FromFile( filePath );

         // Assert

         commitDocument.Subject.Should().Be( subject );
      }

      [Fact]
      public void FromFile_CommitFileHasCommentsBeforeSubject_PopulatesSubject()
      {
         const string filePath = "DoesntMatter";
         const string subject = "DoesntMatter";

         var lines = new[]
         {
            "# A comment",
            subject
         };

         // Arrange

         var fileSystemMock = new Mock<IFileSystem>();
         fileSystemMock.Setup( fs => fs.FileExists( filePath ) ).Returns( true );
         fileSystemMock.Setup( fs => fs.ReadAllLines() ).Returns( lines );

         // Act

         var commitFileReader = new CommitFileReader( fileSystemMock.Object );

         var commitDocument = commitFileReader.FromFile( filePath );

         // Assert

         commitDocument.Subject.Should().Be( subject );
      }

      [Fact]
      public void FromFile_CommitFileStartsWithBlankLine_PopulatesSubject()
      {
         const string filePath = "DoesntMatter";
         const string subject = "DoesntMatter";

         var lines = new[]
         {
            "",
            subject
         };

         // Arrange

         var fileSystemMock = new Mock<IFileSystem>();
         fileSystemMock.Setup( fs => fs.FileExists( filePath ) ).Returns( true );
         fileSystemMock.Setup( fs => fs.ReadAllLines() ).Returns( lines );

         // Act

         var commitFileReader = new CommitFileReader( fileSystemMock.Object );

         var commitDocument = commitFileReader.FromFile( filePath );

         // Assert

         commitDocument.Subject.Should().Be( subject );
      }
   }
}
