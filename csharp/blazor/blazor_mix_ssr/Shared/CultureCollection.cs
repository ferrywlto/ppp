using System.Globalization;

namespace blazor_mix_ssr.Shared;

public static class CultureCollection {
    public static List<CultureInfo> SupportedCultures = new List<CultureInfo> {
        new CultureInfo("en-GB"),
        new CultureInfo("en-US"),
        new CultureInfo("zh-HK"),
        new CultureInfo("zh-TW"),
        new CultureInfo("ja-JP"),
    };

    static CultureCollection() {
        var defaultCulture = SupportedCultures[0];

        CultureInfo.CurrentUICulture = defaultCulture;
        CultureInfo.CurrentCulture = defaultCulture;
        CultureInfo.DefaultThreadCurrentUICulture = defaultCulture;
        CultureInfo.DefaultThreadCurrentCulture = defaultCulture;

        var installedUiCulture = CultureInfo.InstalledUICulture;
        Console.WriteLine($"Installed UI Culture:");
        PrintCultureInfo(installedUiCulture);

        Console.WriteLine($"Invariant Culture");
        PrintCultureInfo(CultureInfo.InvariantCulture);

        Console.WriteLine($"DefaultThreadCulture");
        PrintCultureInfo(CultureInfo.DefaultThreadCurrentCulture);

        Console.WriteLine($"DefaultThreadUICulture");
        PrintCultureInfo(CultureInfo.DefaultThreadCurrentUICulture);

        Console.WriteLine($"CurrentCulture");
        PrintCultureInfo(CultureInfo.CurrentCulture);

        Console.WriteLine($"CurrentUICulture");
        PrintCultureInfo(CultureInfo.CurrentUICulture);
    }

    public static void PrintCultureInfo(CultureInfo cultureInfo) {
        Console.WriteLine($"\tType: {cultureInfo.CultureTypes}");
        Console.WriteLine($"\tName: {cultureInfo.Name}");
        Console.WriteLine($"\tDisplayName: {cultureInfo.DisplayName}");
        Console.WriteLine($"\tNativeName: {cultureInfo.NativeName}");
        Console.WriteLine($"\tEnglishName: {cultureInfo.EnglishName}");
        Console.WriteLine($"\tTwoLettersName: {cultureInfo.TwoLetterISOLanguageName}");
    }
}
