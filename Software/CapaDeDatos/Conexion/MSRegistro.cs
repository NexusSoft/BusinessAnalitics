﻿using Microsoft.Win32;

namespace CapaDeDatos
{
    public class MSRegistro
    {
        const string NombreProyecto = "Business_Analitics";
        public string GetSetting(string section, string key, string sDefault)
        {
            RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\" + NombreProyecto + "\\" + section);
            string s = sDefault;
            if (rk != null) s = (string)rk.GetValue(key);
            return s;
        }
        public string GetSetting(string section, string key)
        {
            return GetSetting(section, key, "");
        }
        public void SaveSetting(string section, string key, string setting)
        {
            RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"Software\" + NombreProyecto + "\\" + section);
            rk.SetValue(key, setting);
        }
    }
}
