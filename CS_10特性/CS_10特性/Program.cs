using System;
using System.Reflection;

public class HelpAttribute : Attribute
{
    string url;
    string topic;
    public HelpAttribute(string url)
    {
        this.url = url;
    }
    public string Url
    {
        get { return url; }
    }
    public string Topic
    {
        get { return topic; }
        set { topic = value; }
    }
}

[Help("http://msdn.microsoft.com/.../MyClass.htm")]
public class Widget
{
    [Help("http://msdn.microsoft.com/.../MyClass.htm", Topic = "Display")]
    public void Display(string text) { }
}

namespace CS_10特性
{
    class Program
    {
        static void ShowHelp(MemberInfo member)
        {
            HelpAttribute a = Attribute.GetCustomAttribute(member,
                typeof(HelpAttribute)) as HelpAttribute;
            if (a == null)
            {
                Console.WriteLine("No help for {0}", member);
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Help for {0}:", member);
                Console.WriteLine("  Url={0}, Topic={1}", a.Url, a.Topic);
                Console.ReadLine();
            }
        }
        static void Main()
        {
            ShowHelp(typeof(Widget));
            ShowHelp(typeof(Widget).GetMethod("Display"));
        }
    }
}
