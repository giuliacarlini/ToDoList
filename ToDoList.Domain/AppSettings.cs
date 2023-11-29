namespace ToDoList.API
{

    public class AppSettings
    {
        public AppSettings()
        {
            ConnectionStrings = new Connectionstrings();
            TokenConfigurations = new Tokenconfigurations();
            Logging = new Logging();
        }

        public Connectionstrings ConnectionStrings { get; set; }
        public Tokenconfigurations TokenConfigurations { get; set; }
        public Logging Logging { get; set; }
    }

    public class Connectionstrings
    {
        public string Default { get; set; }
    }

    public class Tokenconfigurations
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
        public string SecretJwtKey { get; set; }
    }

    public class Logging
    {
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
        public string MicrosoftAspNetCore { get; set; }
    }

}
