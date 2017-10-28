namespace GitModel.UnitTests.Helpers
{
   internal static class ObjectExtensions
   {
      public static T[] AsArray<T>( this T instance ) => new [] { instance };
   }
}
