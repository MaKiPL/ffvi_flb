using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLB_tool
{

    public class FLBUIPosition
    {
        public int applyDeformation; // this is a boolean, but takes up 4 bytes

        // These do not apply, unless applyDeformation == 1
        public float xScale;
        public float yScale;
        public float xSkew;
        public float ySkew;

        public int xPos; // this value is in sub-pixels, divide by 20.0 to get pixels
        public int yPos; // same as above
    }
}
