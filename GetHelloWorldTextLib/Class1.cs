using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HelloWorld
{
    public interface IGetText
    {
        string GetHelloWorldPlain();
        string GetHelloWorldBold();
        string GetHelloWorldLight(); 



    }
    public class GetConsoleText : IGetText
    {
        public string GetHelloWorldBold()
        {
            return "*** Hello World! ***";
        }

        public string GetHelloWorldLight()
        {
            return "(hello world)";
        }

        public string GetHelloWorldPlain()
        {
            return "Hello World";
        }
    }
    public class GetWebText : IGetText
    {
        public string GetHelloWorldBold()
        {
            return "<h1>Hello World!!</h1>";
        }

        public string GetHelloWorldLight()
        {
            return "<i>(hello world)</i>";
        }

        public string GetHelloWorldPlain()
        {
            return "<span>Hello World</span>";
        }
    }
    public class HelloWorldTextFactory
    {
        public static IGetText GetHelloWorldTextClass(string strGetTextClass)
        {
            if (strGetTextClass == "Console")
                return new GetConsoleText();
            else if (strGetTextClass == "Web")
                return new GetWebText();
            else return new GetConsoleText(); //default


        }
    }
}
