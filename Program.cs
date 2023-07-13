using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics3
{

    class EnglishFrenchDictionaryApp
    {
        private Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
        public void AddWord(string word, List<string> translations)
        {
            dictionary[word] = translations;
        }
        public void RemoveWord(string word)
        {
            dictionary.Remove(word);
        }
        public void RemoveTranslation(string word, string translation)
        {
            if (dictionary.ContainsKey(word))
            {
                dictionary[word].Remove(translation);
            }
        }
        public void UpdateWord(string oldWord, string newWord)
        {
            if (dictionary.ContainsKey(oldWord))
            {
                List<string> translations = dictionary[oldWord];
                dictionary.Remove(oldWord);
                dictionary[newWord] = translations;
            }
        }
        public void UpdateTranslation(string word, string oldTranslation, string newTranslation)
        {
            if (dictionary.ContainsKey(word))
            {
                List<string> translations = dictionary[word];
                int index = translations.IndexOf(oldTranslation);
                if (index != -1)
                {
                    translations[index] = newTranslation;
                }
            }
        }
        public List<string> SearchTranslations(string word)
        {
            if (dictionary.ContainsKey(word))
            {
                return dictionary[word];
            }
            else
            {
                return null;
            }
        }
    }

    class Programh
    {
        static void Main(string[] args)
        {
            EnglishFrenchDictionaryApp app = new EnglishFrenchDictionaryApp();

            List<string> translations1 = new List<string> { "maison", "domicile" };
            app.AddWord("house", translations1);

            List<string> translations2 = new List<string> { "chat", "félin" };
            app.AddWord("cat", translations2);

            List<string> translations = app.SearchTranslations("house");
            if (translations != null)
            {
                Console.WriteLine("Переклади слова 'house':");
                foreach (string translation in translations)
                {
                    Console.WriteLine(translation);
                }
            }
            else
            {
                Console.WriteLine("Слово 'house' не знайдено.");
            }
            app.UpdateWord("house", "home");
            app.UpdateTranslation("cat", "chat", "minou");
            app.RemoveWord("cat");
        }
    }
}
