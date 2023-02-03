using ProductTutorial;
using robotManager.Helpful;
using robotManager.Products;
using System;
using System.Windows.Controls;
using wManager.Plugin;
using wManager.Wow.Helpers;

public class Main : IProduct
{
    private ProductSettingsControl _settingsUserControl;
    private readonly TutorialBot _bot = new TutorialBot();
    public bool IsStarted { get; private set; }

    public void Dispose()
    {
        Logging.Write("ProductTutorial disposed");
    }

    public void Initialize()
    {
        ProductTutorialSettings.Load();
        Logging.Write("ProductTutorial initialized");
    }

    public void Start()
    {
        IsStarted = true;

        if (_bot.FsmSetup())
        {
            SpellManager.UpdateSpellBook();
            CustomClass.LoadCustomClass();
            PluginsManager.LoadAllPlugins();
            Logging.Write("ProductTutorial started");
        }
        else
        {
            IsStarted = false;
            Logging.Write("ProductTutorial failed to start");
        }

    }

    public void Stop()
    {
        _bot.Dispose();
        PluginsManager.DisposeAllPlugins();
        CustomClass.DisposeCustomClass();
        IsStarted = false;
        Logging.Write("ProductTutorial stopped");
    }

    public UserControl Settings
    {
        get
        {
            try
            {
                if (_settingsUserControl == null)
                {
                    _settingsUserControl = new ProductSettingsControl();
                }
                return _settingsUserControl;
            }
            catch (Exception e)
            {
                Logging.WriteError("> Main > Settings(): " + e);
            }
            return null;
        }
    }
}
