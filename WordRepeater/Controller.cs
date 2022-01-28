using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using WordRepeater.Model;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace WordRepeater
{
    public static class Controller
    {
        public static List<Language> Languages { get; private set; }//Список языков
        public static Settings sSettings;
        public static UserData udUserData;
        public static List<WordToLearn> wtlWordsToLearn;
        public static void Init()
        {
            sSettings = new Settings();
            udUserData = new UserData();
            wtlWordsToLearn = new List<WordToLearn>();
        }
        public static Language AddNewLanguage(string language)
        {
            Language lLanguage = new Language(language);
            if (null != Languages)
                Languages.Add(lLanguage);
            else
            {
                Languages = new List<Language>();
                Languages.Add(lLanguage);
            }
            SaveLanguages();
            return lLanguage;
        }

        public static bool HasLanguage(string sLanguage)
        {
            if (null == Languages)
                return false;
            foreach (Language l in Languages)
            {
                if (l.sName.Equals(sLanguage))
                {
                    return true;
                }
            }
                return false;
        }

        public static Language GetCurrentLanguage(int index)
        {
            return Languages[index];
        }

        public static void AddNewWordToDictionary(WordToLearn wtlWordToLearn)
        {
            wtlWordsToLearn.Add(wtlWordToLearn);
            SaveDictionary();
        }
        public static void SaveLanguages()
        {
            try
            {
                string jsonString = JsonSerializer.Serialize(Languages);
                File.WriteAllText(Program.PATH + "\\UserData\\languages.json", jsonString);
            }
            catch(Exception e)
            {

            }
        }
        public static void SaveDictionary()
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                Stream fs = File.Create(Program.PATH + "\\UserData\\dictionary");
                fs.Position = 0;
                formatter.Serialize(fs, wtlWordsToLearn);
                fs.Flush();
                fs.Close();

            }
            catch(Exception e)
            {

            }
        }
        public static void SaveSettings()
        {
            try
            {
                string jsonString = JsonSerializer.Serialize<Settings>(sSettings);
                File.WriteAllText(Program.PATH + "\\UserData\\settings.json", jsonString);
            }
            catch (Exception e)
            {

            }
        }

        public static void LoadDictionary()
        {
            try
            {
                if (!File.Exists(Program.PATH + "\\UserData\\dictionary"))
                    return;
                BinaryFormatter formatter = new BinaryFormatter();
                Stream fs = File.Open(Program.PATH + "\\UserData\\dictionary", FileMode.Open);
                fs.Position = 0;
                wtlWordsToLearn=(List<WordToLearn>)formatter.Deserialize(fs);
                fs.Close();
                            }
            catch(Exception e)
            {

            }
        }
    }
}
