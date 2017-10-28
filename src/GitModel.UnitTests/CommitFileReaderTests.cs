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
   }
}
