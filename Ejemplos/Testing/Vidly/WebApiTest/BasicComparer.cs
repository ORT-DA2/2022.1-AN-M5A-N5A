using System.Collections;
using Domain;
namespace WebApiTest
{
    public class BasicComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            Restaurant basicExpected = x as Restaurant;
            Restaurant basicReturned = y as Restaurant;

            bool equals = basicExpected.Id == basicReturned.Id && basicExpected.Name == basicReturned.Name ;
           return equals ? 0 : -1;
        }
    }
}