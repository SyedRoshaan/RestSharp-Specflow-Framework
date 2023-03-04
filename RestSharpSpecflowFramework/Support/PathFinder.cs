using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpSpecflowFramework.Support
{
    internal class PathFinder
    {
        public static string GetPath()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string path = currentDirectory;
            while (true)
            {
                if (Directory.Exists(path + "\\RestSharpSpecflowFramework"))
                {
                    return path;
                }
                else
                {
                    path = Directory.GetParent(path).ToString();
                }
            }
        }
    }
}
