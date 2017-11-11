using TechTalk.SpecFlow;

namespace GitModel.AcceptanceTests.Transformations
{
   [Binding]
   public class StringTransformations
   {
      [StepArgumentTransformation]
      public string[] TransformToListOfString( string commaSeparatedList ) =>
         commaSeparatedList.Split( ',' );
   }
}
