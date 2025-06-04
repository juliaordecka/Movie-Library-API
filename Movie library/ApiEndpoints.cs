namespace Movie_library
{
    public static class ApiEndpoints
    {
        private const string ApiBase = "api";
        public static class Movies
        {
            private const string Base = $"{ApiBase}/movies";
            public const string Create = Base; //api/movies
            public const string Get = $"{Base}/{{idOrSlug}}"; //api/movies/id
            public const string GetAll = Base; //api/movies
            public const string Update = $"{Base}/{{id}}"; //api/movies/id
            public const string Delete = $"{Base}/{{id}}";
        }
    }
}
