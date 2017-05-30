using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using HelloWorld;

namespace HelloWorldConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string strTextGettterClass = ConfigurationSettings.AppSettings["TextGetterClass"];   //get name of TextGetter concrete class from web config (GetText classes are apis that produce "hello World text")
                                                                                            // there are different versions of concrete class.  One returns text approp. for web, one for console.  Additional concrete classes can be written as needed.
            string strPrintTextClass = ConfigurationSettings.AppSettings["PrintTextClass"];  //get name of PrintText concrete class from web.config (PrintText classes print the text given to it)
                                                                                             // there are different versions of the concrete class.  One writes out to a console window, one writes to DB.  Additional concrete classes can be written as needed.

            //The design patterns used here are 2  Factory Design patterns (one to get a concrete instance of the TextGetter and one to get a concrete instance of the TextPrinter class)
            // The second, less obvious design pattern used here is the Bridge pattern:  notice that the concrete impl. of TextGetter is passed to the concrete impl. of TextPrinter.  (Double abstraction - loosely coupled)

            IGetText textGetterClass = HelloWorldTextFactory.GetHelloWorldTextClass(strTextGettterClass);  // use factory method to return correct concrete class
            IPrintText textPrinterClass = PrintHelloWorldFactory.GetPrintHelloWorldClass(strPrintTextClass, textGetterClass);  //use factory method to return concrete class
                                                                                                                               //the factory is also passed the concrete class of TextGetter
            textPrinterClass.PrintHelloWorldBold();
            textPrinterClass.PrintHelloWorldPlain();
            textPrinterClass.PrintHelloWorldLight();

            //The purpose of the Bridge Pattern is that any TextGetter implementation can be combined with any TextPrinter implementation.
            // so that for instance  you can use a TextPrinter for Database (DBPrinter concrete class) with TextGetter for web (GetWebText concrete class) (end result:  text appropriate for web is written to database)
            // or you can use a TextPrinter for Console (ConsolePrinter) and a TextGetter for web (GetWebText)   (end result:  text appropriate for web is written to console)
            // note: some of these combinations may not be practical - but any combination of  TextGetter and TextPrinter can be used, and new concrete classes can be written
            // here are some commented out examples that show how easy the Bridge pattern makes combining the two:


            //Additional Example #1
            //IGetText textGetterClass = HelloWorldTextFactory.GetHelloWorldTextClass("Web");  // use factory method to return correct concrete class
            //IPrintText textPrinterClass = PrintHelloWorldFactory.GetPrintHelloWorldClass("PrintToDB", textGetterClass);  //use factory method to return concrete class
            //                                                                                                             //the factory is also passed the concrete class of TextGetter
            //textPrinterClass.PrintHelloWorldBold();
            //textPrinterClass.PrintHelloWorldPlain();
            //textPrinterClass.PrintHelloWorldLight();


            //Additional Example #2
            //IGetText textGetterClass = HelloWorldTextFactory.GetHelloWorldTextClass("Web");  // use factory method to return correct concrete class
            //IPrintText textPrinterClass = PrintHelloWorldFactory.GetPrintHelloWorldClass("PrintToConsole", textGetterClass);  //use factory method to return concrete class
            //                                                                                                                   //the factory is also passed the concrete class of TextGetter
            //textPrinterClass.PrintHelloWorldBold();
            //textPrinterClass.PrintHelloWorldPlain();
            //textPrinterClass.PrintHelloWorldLight();

            //Additional Example #3
            //IGetText textGetterClass = HelloWorldTextFactory.GetHelloWorldTextClass("Console");  // use factory method to return correct concrete class
            //IPrintText textPrinterClass = PrintHelloWorldFactory.GetPrintHelloWorldClass("PrintToDB", textGetterClass);  //use factory method to return concrete class
            //                                                                                                                   //the factory is also passed the concrete class of TextGetter
            //textPrinterClass.PrintHelloWorldBold();
            //textPrinterClass.PrintHelloWorldPlain();
            //textPrinterClass.PrintHelloWorldLight();
        }
    }
}
