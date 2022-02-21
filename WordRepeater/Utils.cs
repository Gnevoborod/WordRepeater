using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordRepeater
{
    class Utils
    {
        public static string Substr(ref string sManipulate, int iStartPos, int iLength)
        {
            char[] manipulate=new char[iLength];
            try
            {
                for (int i = iStartPos; i < iLength; i++)
                {
                    manipulate[i] = sManipulate[i];
                }
                return new string(manipulate);
            }
            
            catch(Exception e)
            {
                return null;
            }
           
        }

        public static string Substr(ref string sManipulate, int iStartPos)
        {
            return new string(sManipulate.ToCharArray(), iStartPos,sManipulate.Length- iStartPos);
        }

        public static int Strchr(ref string sManipulate, char cSymbol)
        {
            int index = -1;
            for(int i=0;i<sManipulate.Length;i++)
            {
                if(sManipulate[i]==cSymbol)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }
    }
}
