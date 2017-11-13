using System;
using Xunit;
using FluentAssertions;

namespace GitModel.UnitTests
{
   public class RebaseFileReaderTests
   {
      [Theory]
      [InlineData( null )]
      [InlineData( "" )]
      public void FromFile_FilePathIsInvalid_ThrowsArgumentException( string filePath )
      {
         var rebaseFileReader = new RebaseFileReader();

         Action fromFile = () => rebaseFileReader.FromFile( filePath );

         fromFile.ShouldThrow<ArgumentException>();
      }
   }
}
