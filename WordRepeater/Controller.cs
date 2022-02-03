using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Win32;
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
        public static bool RepeatWordFormClosed = true;
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
        public static void SaveLanguages()//сохраняем список языков
        {
            Stream fs=null;
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                fs = File.Create(Program.PATH + "UserData\\languages");
                fs.Position = 0;
                formatter.Serialize(fs, Languages);
                fs.Flush();
            }
            catch (Exception e)
            {

            }
            finally
            {
                if(null!=fs)
                fs.Close();
            }
        }
        public static void SaveDictionary()//сохраняем все слова
        {
            Stream fs = null;
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                fs = File.Create(Program.PATH + "UserData\\dictionary");
                fs.Position = 0;
                formatter.Serialize(fs, wtlWordsToLearn);
                fs.Flush();

            }
            catch(Exception e)
            {

            }
            finally
            {
                if (null != fs)
                    fs.Close();
            }
        }
        public static void SaveSettings()
        {
            Stream fs = null;
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                fs = File.Create(Program.PATH + "UserData\\settings");
                fs.Position = 0;
                formatter.Serialize(fs, sSettings);
                fs.Flush();

            }
            catch (Exception e)
            {

            }
            finally
            {
                if (null != fs)
                    fs.Close();
            }

        }

        public static void LoadDictionary()
        {
            Stream fs = null;
            try
            {
                if (!File.Exists(Program.PATH + "UserData\\dictionary"))
                    return;
                BinaryFormatter formatter = new BinaryFormatter();
                fs = File.Open(Program.PATH + "UserData\\dictionary", FileMode.Open);
                fs.Position = 0;
                wtlWordsToLearn = (List<WordToLearn>)formatter.Deserialize(fs);
                fs.Close();
            }
            catch(Exception e)
            {

            }
            finally
            {
                if (null != fs)
                    fs.Close();
            }
        }
        public static void LoadLanguages()
        {
            Stream fs = null;
            try
            {
                if (!File.Exists(Program.PATH + "UserData\\languages"))
                    return;
                BinaryFormatter formatter = new BinaryFormatter();
                fs = File.Open(Program.PATH + "UserData\\languages", FileMode.Open);
                fs.Position = 0;
                Languages = (List<Language>)formatter.Deserialize(fs);
                fs.Close();
            }
            catch (Exception e)
            {

            }
            finally
            {
                if (null != fs)
                    fs.Close();
            }
        }

        public static void LoadSettings()
        {
            Stream fs = null;
            try
            {
                if (!File.Exists(Program.PATH + "UserData\\settings"))
                    return;
                BinaryFormatter formatter = new BinaryFormatter();
                fs = File.Open(Program.PATH + "UserData\\settings", FileMode.Open);
                fs.Position = 0;
                sSettings = (Settings)formatter.Deserialize(fs);
                fs.Close();
            }
            catch (Exception e)
            {

            }
            finally
            {
                if (null != fs)
                    fs.Close();
            }
        }

        public static void AutorunRegistry(bool arg)
        {
            try
            {
                RegistryKey saveKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run\");
                if (arg)
                {
                    saveKey.SetValue("WordRepeater", Program.PRG_PATH);
                }
                else
                {
                    saveKey.DeleteValue("WordRepeater");
                }
                saveKey.Close();
                Controller.SaveSettings();
            }
            catch(Exception e)
            {

            }
        }
    }
}
