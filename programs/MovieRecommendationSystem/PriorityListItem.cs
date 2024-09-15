using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationSystem
{
    public class PriorityListItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Priority { get; set; }
        public override string ToString() // A ToString() metódus felülírása annak érdekében, hogy ha később hivatkozunk egy PriorityListItem lista egy-egy elemére, akkor a Title tulajdonsága alapján beazonosítható legyen
        {
            return Title;
        }
    }
}
