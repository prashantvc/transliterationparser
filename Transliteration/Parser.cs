using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace Transliteration
{
    public class Parser
    {
        public Parser()
        {

            using (var xmlStream = Assembly.GetExecutingAssembly()
                  .GetManifestResourceStream("Transliteration.transliteration.xml"))

            {
                var xml = XDocument.Load(xmlStream);

                Patterns = xml.Descendants("pattern")
                              .Select(p => 
                                      new Pattern(p.Attribute("input").Value, p.Attribute("replacement").Value))
                              .ToList();
            }
        }

        public string Translate(string input){
            Pattern pattern = Patterns.First(p => Regex.IsMatch(input, p.Input));
            return Regex.Replace(input, pattern.Input, pattern.Replacement);
        }

        List<Pattern> Patterns { get; set; }
    }

    class Pattern
    {
        public string Replacement { get; }
        public string Input { get; }

        public Pattern(string input, string replacement)
        {
            Input = input;
            Replacement = replacement;
        }
    }
}
