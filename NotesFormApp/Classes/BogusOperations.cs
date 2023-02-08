using System.Diagnostics;

namespace NotesFormApp.Classes
{
    internal class BogusOperations
    {
        public static void SimpleText()
        {
            var lorem = new Bogus.DataSets.Lorem(locale: "en");
            
            Debug.WriteLine(lorem.Lines());
        }
    }
}
