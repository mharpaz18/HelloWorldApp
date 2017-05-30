using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace HelloWorld
{
    public interface IPrintText
    {
        void PrintHelloWorldBold();
        void PrintHelloWorldLight();
        void PrintHelloWorldPlain();

    }

    public class ConsolePrinter : IPrintText
    {
        IGetText getTextClass;
        public ConsolePrinter(IGetText theGetTextClass)  //constructor is passed in a concrete implementation of 'Text Getter'  could be the text getter for web or console etc.
        {
            getTextClass = theGetTextClass;


        }
        public  void PrintHelloWorldBold()
        {
            string text = getTextClass.GetHelloWorldBold(); // get the text from the concrete impl. of text getter 
            Console.WriteLine(text);                        //print out to console
            
        }

        public  void PrintHelloWorldLight()
        {
            string text = getTextClass.GetHelloWorldLight();  // get the text from the concrete impl. of text getter 
            Console.WriteLine(text);                            //print out to console
            
        }

        public  void PrintHelloWorldPlain()
        {
            string text = getTextClass.GetHelloWorldPlain();   // get the text from the concrete impl. of text getter 
            Console.WriteLine(text);                            //print out to console
            
        }
    }

    public class DBPrinter : IPrintText
    {
        IGetText getTextClass;
        public DBPrinter(IGetText theGetTextClass)  //constructor is passed in a concrete implementation of 'Text Getter'  could be the text getter for web or console etc.
        {
            getTextClass = theGetTextClass;


        }
        public  void PrintHelloWorldBold()
        {
            string text = getTextClass.GetHelloWorldBold();  // get the text from the concrete impl. of text getter 
            WriteToDB(text);                                  //write the text out to the db
        }

        public  void PrintHelloWorldLight()
        {
            string text = getTextClass.GetHelloWorldLight();// get the text from the concrete impl. of text getter 
            WriteToDB(text);                                  //write the text out to the db
            
        }

        public void PrintHelloWorldPlain()
        {
            string text = getTextClass.GetHelloWorldPlain();// get the text from the concrete impl. of text getter 
            WriteToDB(text);                                  //write the text out to the db
           
        }
        private void WriteToDB(string text)
        {
            //implement writing to Database  // add code to write the text to database.


        }
    }
    public class PrintHelloWorldFactory   
    {
        public static IPrintText GetPrintHelloWorldClass(string strPrintHelloWorldClass, IGetText textGetter)  // returns concrete implementation of text printer based on string passed in. 
        {                                                                                                                   //also accepts a parameter of type: concrete impl. of textGetter
            if (strPrintHelloWorldClass.ToLower() == "printtoconsole")
                return new ConsolePrinter(textGetter);       
            else if (strPrintHelloWorldClass.ToLower() == "printtodb")
                return new DBPrinter(textGetter);
            else return new ConsolePrinter(textGetter); //default
        }
    }

}
