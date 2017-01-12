using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using System.Windows.Forms;
using System.IO;
using System.Security.Permissions;

namespace Bajotumn {
    public class registrySettings {
        private string _RootKey;
        private string RootKey {
            get { return _RootKey; }
            set {
                _RootKey = Path.Combine("Software\\Bajotumn\\", value);
                RegistryPermission perms = new RegistryPermission(RegistryPermissionAccess.AllAccess, Path.Combine(Registry.LocalMachine.ToString(), _RootKey));
                perms.Demand();
                //Console.WriteLine("registrySettings::RootKey = {0}", RootKey);
            }
        }
        /// <summary>
        /// Gets or sets whether or not to display error boxes, default is true
        /// </summary>
        public bool showErrorBoxes {
            get;
            set;
        }


        /// <summary>
        /// Initialize an instance of a registry settings class
        /// </summary>
        /// <param name="key">The name of the application, used as subkey</param>
        public registrySettings(string key) {
            RootKey = key;
            showErrorBoxes = true;
        }
        /// <summary>
        /// Initialize an instance of a registry settings class
        /// </summary>
        /// <param name="key">The name of the application, used as subkey</param>
        /// <param name="errorBoxes">Show error boxes, default is true</param>
        public registrySettings(string key, bool errorBoxes) {
            RootKey = key;
            showErrorBoxes = errorBoxes;
        }

        /// <summary>
        /// Loads a setting
        /// </summary>
        /// <param name="settingName">Name of the setting's key</param>
        /// <param name="defaultValue">Default value to return</param>
        /// <returns>An object with the value retrieved from the key or default value, returns null on error</returns>
        public object loadSetting(string settingName, object defaultValue) {
            object returnValue = null;
            //Console.Write("Loading setting: [{0} = {1}]", settingName, defaultValue);
            try {
                RegistryKey key = Registry.CurrentUser;
                if ((key = key.OpenSubKey(RootKey, false)) != null) {
                    returnValue = key.GetValue(settingName, defaultValue);
                }else {
                    return defaultValue;
                }
                //Console.WriteLine(" = {0}", returnValue);
            } catch {
                showError("Unable to open key(" + RootKey + ") for writing!", "Setting load error: ");
            }
            return returnValue;
        }
        /// <summary>
        /// Saves a setting
        /// </summary>
        /// <param name="settingName">Name of the setting's key</param>
        /// <param name="value">Value to save</param>
        /// <returns>Returns false if save errors</returns>
        public bool saveSetting(string settingName, object value) {
            //Console.WriteLine("Saving setting: {0} = {1}", settingName, value);
            try {
            save:
                RegistryKey key = Registry.CurrentUser;
                if ((key = key.OpenSubKey(RootKey, true)) != null) {
                    key.SetValue(settingName, value);
                } else {
                    key = Registry.CurrentUser;
                    key.CreateSubKey(RootKey);
                    goto save;
                }
                return true;
            } catch (Exception e) {
                showError("Unable to open key(" + RootKey + ") for writing!\n\n" + e.Message, "Setting save error: ");
                return false;
            }
        }


        /// <summary>
        /// Show an error box
        /// </summary>
        /// <param name="message">Message to display</param>
        /// <param name="title">Title of message box</param>
        private void showError(object message, object title) {
            if (showErrorBoxes) {
                MessageBox.Show(message.ToString(), title.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
