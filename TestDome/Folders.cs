using Challenges.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace Challenges.TestDome;
/// <summary>
/// https://www.testdome.com/questions/c-sharp/folders/96027
/// </summary>
internal class Folders : IStartable
{
    public void Start()
    {
        string xml =
    "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
    "<folder name=\"c\">" +
        "<folder name=\"program files\">" +
            "<folder name=\"uninstall information\" />" +
        "</folder>" +
        "<folder name=\"users\" />" +
    "</folder>";

        foreach (string name in Folders.FolderNames(xml, 'u'))
            Console.WriteLine(name);
    }

    //public static IEnumerable<string> FolderNames(string xml, char startingLetter)
    //{
    //    Regex exName = new($@"<folder.*? name=""({startingLetter}.*?)"".*?/?>");
    //    return exName.Matches(xml).Select(m => m.Groups[1].Value);
    //}

    public static IEnumerable<string> FolderNames(string xml, char startingLetter)
    {
        XmlDocument document = new();
        document.LoadXml(xml);
        List<string> attributes = new();
        foreach (XmlAttributeCollection attributeCollection in document.SelectNodes(@"//folder").Cast<XmlNode>().Select(node => node.Attributes))
        {
            foreach (XmlAttribute atribute in attributeCollection.Cast<XmlAttribute>().Where(a => a.Name == "name"))
            {
                attributes.Add(atribute.Value);
            }
        }
        attributes = attributes.Where(a => a.Trim().StartsWith(startingLetter)).Distinct().ToList();

        return attributes;
    }
}
