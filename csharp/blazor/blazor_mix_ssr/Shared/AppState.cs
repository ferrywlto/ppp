namespace blazor_mix_ssr.Shared;

public class InjectAppState {
    public int CurrentCount { get; set; }
}

public static class StaticAppState  {
    public static int CurrentCount { get; set; }
}
