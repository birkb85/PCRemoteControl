using System.Configuration;

public class SettingsService : ApplicationSettingsBase
{
    // https://learn.microsoft.com/en-us/dotnet/desktop/winforms/advanced/how-to-create-application-settings?view=netframeworkdesktop-4.8
    // C:\Users\[USER]\AppData\Local\PCRemoteControl\PCRemoteControl_Url_wv3vrqz2euvf0wd3mdobmytsv4wuhmzw\1.0.0.0
    [UserScopedSetting()]
    [DefaultSettingValue("8080")]
    public string ServerPort
    {
        get
        {
            return (string)this[nameof(ServerPort)];
        }
        set
        {
            this[nameof(ServerPort)] = value;
        }
    }

    [UserScopedSetting()]
    [DefaultSettingValue("true")]
    public bool ShowAtStartup
    {
        get
        {
            return (bool)this[nameof(ShowAtStartup)];
        }
        set
        {
            this[nameof(ShowAtStartup)] = value;
        }
    }
}