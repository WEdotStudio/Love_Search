
using System;
using System.IO.IsolatedStorage;
using System.Diagnostics;

namespace sdkSettingsCS
{
    public class AppSettings
    {

        IsolatedStorageSettings settings;

        const string CheckBox1SettingKeyName = "CheckBox1Setting";
        const string CheckBox2SettingKeyName = "CheckBox2Setting";
        const string CheckBox3SettingKeyName = "CheckBox3Setting";
        const string CheckBox4SettingKeyName = "CheckBox4Setting";
        const string CheckBox5SettingKeyName = "CheckBox5Setting";

        const bool CheckBox1SettingDefault = true;
        const bool CheckBox2SettingDefault = true;
        const bool CheckBox3SettingDefault = true;
        const bool CheckBox4SettingDefault = true;
        const bool CheckBox5SettingDefault = false;



        public AppSettings()
        {
            try
            {
                settings = IsolatedStorageSettings.ApplicationSettings;

            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception while using IsolatedStorageSettings: " + e.ToString());
            }
        }


        public bool AddOrUpdateValue(string Key, Object value)
        {
            bool valueChanged = false;

            if (settings.Contains(Key))
            {
                if (settings[Key] != value)
                {
                    settings[Key] = value;
                    valueChanged = true;
                }
            }
            else
            {
                settings.Add(Key, value);
                valueChanged = true;
            }

            return valueChanged;
        }

        public valueType GetValueOrDefault<valueType>(string Key, valueType defaultValue)
        {
            valueType value;

            if (settings.Contains(Key))
            {
                value = (valueType)settings[Key];
            }
            else
            {
                value = defaultValue;
            }

            return value;
        }

        public void Save()
        {
            settings.Save();
        }


        public bool CheckBox1Setting
        {
            get
            {
                return GetValueOrDefault<bool>(CheckBox1SettingKeyName, CheckBox1SettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(CheckBox1SettingKeyName, value))
                {
                    Save();
                }
            }
        }

        public bool CheckBox2Setting
        {
            get
            {
                return GetValueOrDefault<bool>(CheckBox2SettingKeyName, CheckBox2SettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(CheckBox2SettingKeyName, value))
                {
                    Save();
                }
            }
        }
        public bool CheckBox3Setting
        {
            get
            {
                return GetValueOrDefault<bool>(CheckBox3SettingKeyName, CheckBox3SettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(CheckBox3SettingKeyName, value))
                {
                    Save();
                }
            }
        }
        public bool CheckBox4Setting
        {
            get
            {
                return GetValueOrDefault<bool>(CheckBox4SettingKeyName, CheckBox4SettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(CheckBox4SettingKeyName, value))
                {
                    Save();
                }
            }
        }
        public bool CheckBox5Setting
        {
            get
            {
                return GetValueOrDefault<bool>(CheckBox5SettingKeyName, CheckBox5SettingDefault);
            }
            set
            {
                if (AddOrUpdateValue(CheckBox5SettingKeyName, value))
                {
                    Save();
                }
            }
        }
        
 


    }
}
