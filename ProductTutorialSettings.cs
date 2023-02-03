using robotManager.Helpful;
using System;
using System.IO;
using wManager.Wow.Helpers;
using wManager.Wow.ObjectManager;

namespace ProductTutorial
{
    public class ProductTutorialSettings : Settings
    {
        private static readonly string _productName = "ProductTutorial";
        private static string GetSettingsPath => AdviserFilePathAndName(_productName, ObjectManager.Me.Name + "." + Usefuls.RealmName);
        public static ProductTutorialSettings CurrentSettings { get; set; }

        public string LeaderName { get; set; }
        public int FollowDistance { get; set; }

        public ProductTutorialSettings()
        {
            LeaderName = string.Empty;
            FollowDistance = 10;
        }

        public bool Save()
        {
            try
            {
                return Save(GetSettingsPath);
            }
            catch (Exception ex)
            {
                Logging.WriteError("ProductTutorialSettings > Save(): " + ex);
                return false;
            }
        }

        public static bool Load()
        {
            try
            {
                if (File.Exists(GetSettingsPath))
                {
                    CurrentSettings = Load<ProductTutorialSettings>(GetSettingsPath);
                    return true;
                }
                CurrentSettings = new ProductTutorialSettings();
            }
            catch (Exception ex)
            {
                Logging.WriteError("ProductTutorialSettings > Load(): " + ex);
            }
            return false;
        }
    }
}
