using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormApp
{
    public class Flag
    {
        public String FlagName;
        public Image FlagImage;
        
        public Flag(String name, Image image)
        {
            FlagName = name;
            FlagImage = image;
        }
    }
}
