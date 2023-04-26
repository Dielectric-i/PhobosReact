using ErrorOr;

namespace PhobosReact.API.ServicesError
{
    public static class Errors
    {
        public static class Space
        {
            public static Error NotFound => Error.NotFound(
                code: "Space.NotFound",
                description: "Space not found"
                );
            public static Error RepositoryExceprion(Exception ex) => Error.Failure(

                 code: "Space.RepositoryExceprion",
                description: "Some problem occured in SpaceRepository"
                );
        }

        public static class Box
        {
            public static Error NotFound => Error.NotFound(
                code: "Box.NotFound",
                description: "Box not found"
                );
            public static Error RepositoryExceprion(Exception ex) => Error.Failure(

                 code: "Box.RepositoryExceprion",
                description: "Some problem occured in BoxRepository"
                );
        }
    }
}
