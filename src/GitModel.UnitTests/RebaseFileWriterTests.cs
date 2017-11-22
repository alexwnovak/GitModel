using System;
using FluentAssertions;
using GitModel.Internal;
using Moq;
using Xunit;

namespace GitModel.UnitTests
{
   public class RebaseFileWriterTests
   {
      [Theory]
      [InlineData( null )]
      [InlineData( "" )]
      public void ToFile_FilePathIsInvalid_ThrowsArgumentException( string filePath )
      {
         var rebaseFileWriter = new RebaseFileWriter( Mock.Of<IFileSystem>() );

         Action toFile = () => rebaseFileWriter.ToFile( filePath, null );

         toFile.ShouldThrow<ArgumentException>();
      }

      [Fact]
      public void ToFile_RebaseDocumentIsNull_ThrowsArgumentException()
      {
         var rebaseFileWriter = new RebaseFileWriter( Mock.Of<IFileSystem>() );

         Action toFile = () => rebaseFileWriter.ToFile( "NotNullString", null );

         toFile.ShouldThrow<ArgumentException>();
      }
   }
}
