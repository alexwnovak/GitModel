using System;
using Xunit;
using FluentAssertions;

namespace GitModel.UnitTests
{
   public class CommitFileReaderTests
   {
      [Fact]
      public void FromFile_FilePathIsNull_ThrowsArgumentException()
      {
         var commitFileReader = new CommitFileReader();

         Action fromFile = () => commitFileReader.FromFile( null );

         fromFile.ShouldThrow<ArgumentException>();
      }

      [Fact]
      public void FromFile_FilePathIsEmptyString_ThrowsArgumentException()
      {
         var commitFileReader = new CommitFileReader();

         Action fromFile = () => commitFileReader.FromFile( string.Empty );

         fromFile.ShouldThrow<ArgumentException>();
      }
   }
}
