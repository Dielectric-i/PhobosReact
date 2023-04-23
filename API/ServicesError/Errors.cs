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
            public static Error CreationFailed(Exception ex) => Error.Failure(

                 code: "Space.CreationFailed",
                description: "Failed to create Space"
                );
        }

        public static class Box
        {
            public static Error NotFound => Error.NotFound(
                code: "Box.NotFound",
                description: "Box not found"
                );
            public static Error RepositoryExceprion(Exception ex) => Error.Failure(

                 code: "Box.CreationFailed",
                description: "Failed to create Box"
                );
        }
    }
}
